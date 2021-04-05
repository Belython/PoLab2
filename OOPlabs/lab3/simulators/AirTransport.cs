using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace simulator
{
    public class AirTransport : Vehicle
    {
        public double DistanceReducer;

        public AirTransport(string name, double speed, double distanceReducer)
            : base(name, speed)
        {
            DistanceReducer = distanceReducer;
        }
        public override double calc(double dis)
        {
            throw new NotImplementedException();
        }
    }
}
