using System;

namespace simulator
{
    public class CamelSpeedBoat : EarthTransport
    {
        public CamelSpeedBoat()
            : base("CamelSppedBoat", 40, 10, 5)

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
                if (countStop == 1)
                {
                    time = (dis / Speed) + relax;
                    return time;
                }
                else if(countStop == 2)
                {
                    time = (dis / Speed) + (countStop * relax) + relax + 6.5;
                    return time;
                }
                else
                {
                    time = (dis / Speed) + (countStop * relax) + relax + 6.5 + (countStop - 2) * 8;
                    return time;
                }
            }
        }
    }
}
