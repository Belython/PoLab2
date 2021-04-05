using NUnit.Framework;
using simulator;

namespace simulatorTest
{
    [TestFixture]
    public class Two_humped_CamelTest
    {
        public void SetUp()
        {

        }
        [Test]
        public void Two_humped_Cameltest()
        {
            Two_humped_Camel camel = new Two_humped_Camel();
            var actual = camel.calc(800);
            var expented = 101;
            Assert.AreEqual(expented, actual);
        }
    }
}