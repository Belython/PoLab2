using NUnit.Framework;
using simulator;
using System.Collections.Generic;

namespace simulatorTest
{
    [TestFixture]
    public class AirEarthRaceTest
    {
        public void SetUp()
        {

        }
        [Test]
        public void AirEarthRacetest()
        {
            Centaur cen = new Centaur();
            Two_humped_Camel twoHumpedCamel = new Two_humped_Camel();
            Magiccarpet carpet = new Magiccarpet();
            Mortar mortar = new Mortar();
            Broom broom = new Broom();
            Bootsalltrains boot = new Bootsalltrains();
            CamelSpeedBoat camelspped = new CamelSpeedBoat();
            AirEarthRace race = new AirEarthRace(new List<EarthTransport> { cen, camelspped, twoHumpedCamel, boot }, new List<AirTransport> { carpet, broom, mortar });
            var actual = race.calc(100);
            var expented = "CamelSppedBoat";
            Assert.AreEqual(expented, actual);
        }
    }
}