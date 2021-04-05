using System;

namespace simulator
{
    public class Broom : AirTransport
    {
        public Broom()
            : base("broom", 1, 20)

        { }
        public override double calc(double dis)
        {
            int count = (int)(dis / 1000);
            double resDis = dis * ((100 - count) / 100);
            return resDis / Speed;
        }
    }
}
