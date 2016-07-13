using NUnit.Framework;
using System;

namespace Test1 {
    [TestFixture()]
    public class Test {
        [Test()]
        public void TestCase() {
        }

        [Test()]
        public void TestCase2() {
            Assert.False(true);
        }
    }
}

