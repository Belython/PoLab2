using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{
    interface IElement
    {
        IElement Clone();

        string Info();
    }

    class Button : IElement
    {
        protected double w;
        protected double h;

        public Button(double w, double h)
        {
            this.w = w;
            this.h = h;
        }

        public Button(Button other)
        {
            w = other.w;
            h = other.h;
        }

        public IElement Clone()
        {
           return new Button(this);
        }

        public string Info()
        {
            return $"Кнопка {w}x{h}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var btn = new Button(40, 15);
            var elem = btn.Clone();
            Console.WriteLine(elem.Info());
        }
    }
}
