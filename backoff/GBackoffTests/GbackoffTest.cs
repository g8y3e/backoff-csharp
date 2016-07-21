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
        }
    }
}

