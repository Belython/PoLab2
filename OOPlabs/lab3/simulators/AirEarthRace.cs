using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace simulator
{
    public class AirEarthRace
    {
        private List<Vehicle> alList;

        public AirEarthRace(List<Vehicle> alList)
        {
            if (alList.Count < 1)
            {
                throw new ExceptionSimulator.EmptyException();
            }
            this.alList = alList;
        }

        public string calc(double dis)
        {

            int count = 0;
            double winTime = alList[0].calc(dis);
            for (var i = 0; i < alList.Count; i++)
            {
                double temp = alList[i].calc(dis);
                if (temp < winTime)
                {
                    winTime = temp;
                    count = i;
                }
            }
            return alList[count].Name;
        }
    }
}
