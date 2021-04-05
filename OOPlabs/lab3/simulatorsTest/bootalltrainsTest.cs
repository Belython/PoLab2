using NUnit.Framework;
using simulator;

namespace simulatorTest
{
    [TestFixture]
    public class bootalltrainsTest
    {
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void bootalltrainstest()
        {
            Bootsalltrains boot = new Bootsalltrains();
            var actual = boot.calc(366);
            var expented = 71;
            Assert.AreEqual(expented, actual);
        }
    }
}