using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;

namespace Patterns
{
    class Image
    {}

    class Exercise
    {
        private int Id;
        private double Duration;
        private Image[] Images;
        public Exercise(int id, double duration, Image[] img)
        {
            Id = id;
            Duration = duration;
            Images = img;
        }

        public void Show(int step)
        {
            var img = Images[step];
            Console.WriteLine($"Show {step} image");
        }
    }

    class Exercisefactory
    {
        Dictionary<int, Exercise> _cache = new Dictionary<int, Exercise>();
        public Exercise Get(int id)
        {
            if (!_cache.TryGetValue(id, out var ex))
            {
                ex = FetchFromRerver(id);
                _cache[id] = ex;
            }

            return ex;
        }

        protected Exercise FetchFromRerver(int id)
        {
            return new Exercise(id, 10.0, new Image[]{});
        }
    }

    class Workout
    {
        private Exercise _ex;
        private int _step;

        public Workout(Exercise ex)
        {
            _ex = ex;
            _step = 0;
        }

        public void DoIt()
        {
            _ex.Show(_step);
            ++_step;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var fartory = new Exercisefactory();
            var ex = fartory.Get(2);
            var wo = new Workout(ex);
            wo.DoIt();
        }
    }
}
