namespace simulator
{
    public class Mortar : AirTransport
    {
        public Mortar()
            : base("mortar", 6, 8)

        { }


        public override double calc(double dis)
        {
            double resTime = dis * ((100 - DistanceReducer) / 100);
            return resTime / Speed;
        }
    }
}
