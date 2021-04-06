using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{
    class Pizza
    {
        public Pizza(string dough, string[] indigrients)
        {
            Dough = dough;
            Indigrients = indigrients;
        }
        public string Dough { get; set; }
        public string [] Indigrients { get; set; }
    }

    interface IPiazzaBuilder
    {
        IPiazzaBuilder SetDough(string dough);
        IPiazzaBuilder SetIndigrient(string[] indigrients);

        Pizza Build();
    }

    class PepperoniBuilder : IPiazzaBuilder
    {
        protected string dough;
        protected List<string> indigrients;

        public IPiazzaBuilder SetDough(string dough)
        {
            this.dough = dough;
            return this;
        }

        public IPiazzaBuilder SetIndigrient(string[] indigrients)
        {
            this.indigrients = new List<string>(indigrients);
            return this;
        }

        public Pizza Build()
        {
            return new Pizza(dough, indigrients.ToArray());
        }
    }

    class PizzaMarker
    {
        protected IPiazzaBuilder builder;

        public PizzaMarker(IPiazzaBuilder builder)
        {
            this.builder = builder;
            builder.SetDough("тонкое").SetIndigrient(new string[] {"cheese", "sous"});
        }

        public Pizza Make()
        {
            return builder.Build();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var maker = new PizzaMarker(new PepperoniBuilder());
            maker.Make();
        }
    }
}
