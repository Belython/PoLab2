using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace simulator
{
    class Programm
    {

        static void Main(string[] args)
        {
            Centaur cen = new Centaur();
            Two_humped_Camel twoHumpedCamel = new Two_humped_Camel();
            Magiccarpet carpet = new Magiccarpet();
            Mortar mortar = new Mortar();
            Broom broom = new Broom();
            Bootsalltrains boot = new Bootsalltrains();
            CamelSpeedBoat camelspped = new CamelSpeedBoat();
            Race<EarthTransport> race1 = new Race<EarthTransport>(new List<EarthTransport> { cen, camelspped, twoHumpedCamel, boot });
            Race<AirTransport> race2 = new Race<AirTransport>(new List<AirTransport> { carpet, broom, mortar});
            AirEarthRace race3 = new AirEarthRace(new List<EarthTransport> { cen, camelspped, twoHumpedCamel, boot }, new List<AirTransport> { carpet, broom, mortar });
            Console.WriteLine(twoHumpedCamel.calc(300));
            Console.WriteLine(cen.calc(300));
            Console.WriteLine(boot.calc(300));
            Console.WriteLine(camelspped.calc(300));
            Console.WriteLine(carpet.calc(300));
            Console.WriteLine(mortar.calc(300));
            Console.WriteLine(broom.calc(300));
            Console.WriteLine(race1.calc(300));
            Console.WriteLine(race2.calc(300));
            Console.WriteLine(race3.calc(300));
        }
    }
}
