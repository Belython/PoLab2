using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{
    using Payload = List<Tuple<string, double>>;
    interface IBank
    {
        void Notify(Payload p);
    }

    interface INotifiler
    {
        void Notify(Payload p);
    }

    class Stock : INotifiler
    {
        private List<IBank> _subc = new List<IBank>();

        public void register(IBank b) => _subc.Add(b);
        public void unregister(IBank b) => _subc.Remove(b);

        public void Market()
        {
            var rnd = new Random();
            var euro = rnd.NextDouble() * 20 + 70;
            var dollar = rnd.NextDouble() * 20 + 60;
            Notify(new Payload { Tuple.Create("euro", euro), Tuple.Create("dollar", dollar)});
        }

        public void Notify(Payload p)
        {
            foreach (var s in _subc)
            {
                s.Notify(p);
            }
        }
    }

    class Bank : IBank
    {
        public void Notify(Payload p)
        {
            foreach (var c in p)
            {
                Console.WriteLine(($"{c.Item1} курс: {c.Item2}"));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stock();
            var b = new Bank();

            s.register(b);
            s.Market();
        }
    }
}
