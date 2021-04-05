using System;

namespace simulator
{
    public class Two_humped_Camel : EarthTransport
    {
        public Two_humped_Camel()
            : base("Two humped camel", 10, 30, 5)

        { }

        public override double calc(double dis)
        {
            double time;
            if (dis <= Speed * timeToRelax)
            {
                return (dis / Speed);
            }
            else
            {
                int countStop = (int)(dis / Speed / timeToRelax);
                if (countStop > 1)
                {
                    time = (dis / Speed) + (countStop * 8) + relax;
                    return time;
                }
                else
                {
                    time = (dis / Speed) + (countStop * relax);
                    return time;
                }
            }
        }
    }
}
