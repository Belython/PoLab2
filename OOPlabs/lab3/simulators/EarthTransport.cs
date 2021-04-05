using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace simulator
{
    public class EarthTransport : Vehicle
    {
        public double timeToRelax;
        public double relax;
        public EarthTransport(string name, double speed, double TimeToRelax, double Relax)
            : base(name, speed)
        {
            timeToRelax = TimeToRelax;
            relax = Relax;
        }
        public override double calc(double dis)
        {
            throw new NotImplementedException();
        }

    }
}
