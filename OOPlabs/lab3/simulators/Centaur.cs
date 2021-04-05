namespace simulator
{
    public class Centaur : EarthTransport
    {
        public Centaur()
            : base("centaur", 15, 8, 2)

        { }
        public override double calc(double dis)
        {
            if (dis <= Speed * timeToRelax)
            {
                return (dis / Speed);
            }
            else
            {
                int countStop = (int)(dis / Speed / timeToRelax);
                double time = (dis / Speed) + (countStop * relax);
                return time;
            }
        }
    }
}
