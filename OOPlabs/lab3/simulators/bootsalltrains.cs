namespace simulator
{
    public class Bootsalltrains : EarthTransport
    {
        public Bootsalltrains()
            : base("bootsalltrains", 6, 60, 10)

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
                    time = (dis / Speed) + (countStop * 5) + relax;
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
