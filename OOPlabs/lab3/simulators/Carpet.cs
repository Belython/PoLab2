using System.Runtime.InteropServices.ComTypes;

namespace simulator
{
    public class Magiccarpet : AirTransport
    {
        public Magiccarpet()
            : base("Magic carpet", 10, 1000)

        { }
        public override double calc(double dis)
        {
            double resDis;
            if ((dis >= 1000) && (dis < 5000))
            {
                resDis = dis * ((100 - DistanceReducer) / 100);
                return resDis / Speed;
            }
            if ((dis >= 5000) && (dis < 10000))
            {
                resDis = dis * 0.9;
                return resDis / Speed;
            }
            if ((dis >= 10000))
            {
                resDis = dis * 0.95;
                return resDis / Speed;
            }

            return dis / Speed;
        }
    }
}
