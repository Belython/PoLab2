using NUnit.Framework;
using simulator;

namespace simulatorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CentaurTest()
        {
            Centaur cen = new Centaur();
            var actual = cen.calc(120);
            var expented = 8;
            Assert.AreEqual(expented, actual);
        }
    }
}