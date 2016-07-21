using NUnit.Framework;

namespace gbase {
    namespace test {
        [TestFixture]
        public class GbackoffTest {
            [Test]
            public void TestWithoutJitter() {
                var backoff = new gbase.Backoff();

                double firstDuration = backoff.GetDuration();
                double secondDuration = backoff.GetDuration();
                Assert.AreEqual(firstDuration * 2, secondDuration);	
            }

            [Test]
            public void TestWithJitter() {
                var backoff = new gbase.Backoff();

                backoff.EnableJitter(true);

                double firstDuration = backoff.GetDuration();
                double secondDuration = backoff.GetDuration();
                Assert.AreNotEqual(firstDuration * 2, secondDuration);
            }

            [Test]
            public void TestReset() {
                var backoff = new gbase.Backoff();

                backoff.Reset();

                int expectedAttempt = 0;

                Assert.AreEqual(expectedAttempt, backoff.GetAttempt());
            }

            [Test]
            public void TestGetDuration() {
                var backoff = new gbase.Backoff();

                double firstDuration = backoff.GetDuration();
                double secondDuration = backoff.GetDuration();
                Assert.AreEqual(firstDuration * 2, secondDuration);
            }

            [Test]
            public void TestFactor() {
                var backoff = new gbase.Backoff();

                int expectedFactor = 20;
                backoff.SetFactorTime(expectedFactor);

                double currentFactor = backoff.GetFactorTime();
                Assert.AreEqual(expectedFactor, currentFactor);
            }

            [Test]
            public void TestMaxMinTime() {
                var backoff = new gbase.Backoff();

                double expectedMinTime = 0.5;
                double expectedMaxTime = 1.0;

                backoff.SetMinTime(expectedMinTime);
                backoff.SetMaxTime(expectedMaxTime);

                Assert.AreEqual(expectedMinTime, backoff.GetMinTime());
                Assert.AreEqual(expectedMaxTime, backoff.GetMaxTime());
            }
        }
    }
}

