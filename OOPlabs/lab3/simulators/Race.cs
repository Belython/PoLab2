using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace simulator
{
    class Race<T> where T : Vehicle
    {
        private List<T> race;

        public Race(List<T> race)
        {
            if (race.Count < 1)
            {
                throw new ExceptionSimulator.EmptyException();
            }
            this.race = race;
        }

        public string calc(double dis)
        {
            int count = 0;
            double wintTime = race[0].calc(dis);
            for (var i = 0; i < race.Count; i++)
            {
                double temp = race[i].calc(dis);
                if (temp < wintTime)
                {
                    wintTime = temp;
                    count = i;
                }
            }
            return race[count].Name;
        }
    }
}

