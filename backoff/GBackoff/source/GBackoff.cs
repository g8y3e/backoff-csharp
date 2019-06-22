using System;
namespace gbase
{
    public class Backoff
    {
        private const double DEFAULT_MIN_TIME_ = 1;
        private const double DEFAULT_MAX_TIME_ = 10;

        private const int DEFAULT_FACTOR_TIME_ = 2;

        private double minTime_;
        private double maxTime_;

        private int factorTime_;

        private bool isJitter_;
        private int attempt_;

        private Random random_;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:gbase.Backoff"/> class.
        /// </summary>
        /// <param name="minTime">Minimum time.</param>
        /// <param name="maxTime">Max time.</param>
        /// <param name="factorTime">Factor time.</param>
        /// <param name="isJitter">Is jitter.</param>
        public Backoff(bool isJitter = true, double minTime = DEFAULT_MIN_TIME_, double maxTime = DEFAULT_MAX_TIME_, int factorTime = DEFAULT_FACTOR_TIME_)
        {
            attempt_ = 0;

            factorTime_ = factorTime;

            minTime_ = minTime;
            maxTime_ = maxTime;
            isJitter_ = isJitter;

            random_ = new Random();
        }

        public void SetMinTime(double minTime)
        {
            minTime_ = minTime;
        }

        public double GetMinTime()
        {
            return minTime_;
        }

        public void SetMaxTime(double maxTime)
        {
            maxTime_ = maxTime;
        }

        public double GetMaxTime()
        {
            return maxTime_;
        }

        public void SetFactorTime(int factorTime)
        {
            factorTime_ = factorTime;
        }

        public int GetFactorTime()
        {
            return factorTime_;
        }

        public void EnableJitter(bool isJitter)
        {
            isJitter_ = isJitter;
        }

        public double GetDuration()
        {
            double duration = CalculateTime();
            attempt_++;
            return duration;
        }

        public int GetAttempt()
        {
            return attempt_;
        }

        public void Reset()
        {
            attempt_ = 0;
        }

        private double CalculateTime()
        {
            double duration = minTime_ * Math.Pow(factorTime_, attempt_);

            if (isJitter_)
            {
                duration = (random_.NextDouble() * (duration - minTime_)) + minTime_;
            }

            if (duration > maxTime_)
            {
                duration = maxTime_;
            }

            return duration;
        }
    }
}