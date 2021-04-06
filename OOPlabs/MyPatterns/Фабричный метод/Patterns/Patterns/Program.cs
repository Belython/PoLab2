using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{
    interface IBuilding
    {
        public string Name { get; }
        public double Square { get; }
        public double Height { get; }
    }
    class House : IBuilding
    {
        public string Name { get;  set; }
        public double Square { get;  set; }
        public double Height { get;  set; }
    }

    class Bath : IBuilding
    {
        public string Name { get;  set; }
        public double Square { get;  set; }
        public double Height { get;  set; }
    }

    abstract class Developer
    {
        public string Name { get; }

        public Developer(string name)
        {
            Name = name;
        }

        abstract public IBuilding Create();

    }

    class HouseDeveloper : Developer
    {
        public HouseDeveloper(string name) : base(name)
        {
        }

        public override IBuilding Create()
        {
            return new House() {Name = "house", Square = 34, Height = 56};
        }
    }

    class BathDeveloper : Developer
    {
        public BathDeveloper(string name) : base(name)
        {
        }

        public override IBuilding Create()
        {
            return new House() { Name = "Bath", Square = 56, Height = 34 };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Developer d = new HouseDeveloper("dfs");

            var b = d.Create();
            Console.WriteLine(b.Name + " " + b.Square + " " + b.Height);
        }
    }
}
