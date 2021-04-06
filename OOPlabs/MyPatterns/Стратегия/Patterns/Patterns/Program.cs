using System;

namespace Patterns
{
    class Point {}
    class Track { }

    interface IPlanner
    {
        Track Build(Point a, Point b);

    }

    class MapApp
    {
        private IPlanner _planner;

        public void SetPlanner(IPlanner p)
        {
            _planner = p;
        }

        public Track BuildTrack(Point a, Point b) => _planner.Build(a, b);
    }

    class WalkPlanner : IPlanner
    {
        public Track Build(Point a, Point b)
        {
            Console.WriteLine("Маршут от WalkPlanner");
            return new Track();
        }
    }
    class CarPlanner : IPlanner
    {
        public Track Build(Point a, Point b)
        {
            Console.WriteLine("Маршут от CarPlanner");
            return new Track();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var app = new MapApp();

            var a = new Point();
            var b = new Point();

            app.SetPlanner(new WalkPlanner());
            app.BuildTrack(a, b);

            app.SetPlanner(new CarPlanner());
            app.BuildTrack(a, b);
        }
    }
}
