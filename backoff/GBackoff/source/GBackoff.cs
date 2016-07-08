using System;
namespace gbase {
    class Backoff {
        private static double DEFAULT_MIN_TIME_ = 1;
        private static double DEFAULT_MAX_TIME_ = 10;

        private static int DEFAULT_FACTOR_TIME_ = 2;

        private double minTime_;
        private double maxTime_;

        private int factorTime_;

        private bool isJitter_;
        private int attempt_;

        private Random random_;


        public Backoff(double minTime = 0, double maxTime = 0, int factorTime = 0, 
                       bool isJitter = false) {
            attempt_ = 0;

            factorTime_ = factorTime;

            minTime_ = minTime;
            maxTime_ = maxTime;

            if (factorTime_ <= 0.00001) {
                factorTime_ = DEFAULT_FACTOR_TIME_;
            }

            if (minTime_ <= 0.00001) {
                minTime_ = DEFAULT_MIN_TIME_;
            }

            if (maxTime_ <= 0.00002) {
                maxTime_ = DEFAULT_MAX_TIME_;
            }

            isJitter_ = isJitter;

            random_ = new Random();
        }

        public double getDuration() {
            double duration = calculateTime();
            attempt_++;
            return duration;
        }

        public int getAttempt() {
            return attempt_;
        }

        public void reset() {
            attempt_ = 0;
        }

        private double calculateTime() {
            double duration = minTime_ * Math.Pow(maxTime_, factorTime_);

            if (isJitter_) {
                duration = (random_.NextDouble() * (duration - minTime_)) + minTime_;
            }

            if (duration > maxTime_) {
                duration = maxTime_;
            }

            return duration;
        }
    }
}