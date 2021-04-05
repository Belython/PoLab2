using NUnit.Framework;
using simulator;

namespace simulatorTest
{
    [TestFixture]
    public class CarpetTest
    {
        public void SetUp()
        {

        }
        [Test]
        public void Carpettest()
        {
            Magiccarpet carpet = new Magiccarpet();
            var actual = carpet.calc(800);
            var expented = 80;
            Assert.AreEqual(expented, actual);
        }
    }
}