using NUnit.Framework;
using simulator;

namespace simulatorTest
{
    [TestFixture]
    public class CamelSpeedBoatTest
    {
        public void SetUp()
        {

        }
        [Test]
        public void CamelSpeedBoattest()
        {
            CamelSpeedBoat Camel = new CamelSpeedBoat(); 
            var actual = Camel.calc(800);
            var expented = 41.5;
            Assert.AreEqual(expented, actual);
        }
    }
}