using NUnit.Framework;
using simulator;

namespace simulatorTest
{
    [TestFixture]
    public class mortarTest
    {
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void mortartest()
        {
            Mortar mortar = new Mortar();
            var actual = mortar.calc(100);
            var expented = 11.75;
            Assert.AreEqual(expented, actual);
        }
    }
}