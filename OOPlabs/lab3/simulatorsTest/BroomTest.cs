using NUnit.Framework;
using simulator;

namespace simulatorTest
{
    [TestFixture]
    public class BroomTest
    {
        public void SetUp()
        {

        }
        [Test]
        public void Broomtest()
        {
            Broom broom = new Broom();
            var actual = broom.calc(800);
            var expented = 40;
            Assert.AreEqual(expented, actual);
        }
    }
}