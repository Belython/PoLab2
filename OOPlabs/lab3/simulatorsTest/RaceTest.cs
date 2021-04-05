using System.Collections.Generic;
using NUnit.Framework;
using simulator;

namespace simulatorTest
{
    [TestFixture]
    public class RaceTest
    {
        public void SetUp()
        {

        }
        [Test]
        public void Racetest()
        {
            Centaur cen = new Centaur();
            Two_humped_Camel twoHumpedCamel = new Two_humped_Camel();
            Bootsalltrains boot = new Bootsalltrains();
            CamelSpeedBoat camelspped = new CamelSpeedBoat();
            Race<EarthTransport> race = new Race<EarthTransport>(new List<EarthTransport> { cen, camelspped, twoHumpedCamel, boot });
            var actual = race.calc(800);
            var expented = "CamelSppedBoat";
            Assert.AreEqual(expented, actual);
        }
    }
}