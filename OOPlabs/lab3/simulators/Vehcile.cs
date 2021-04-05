using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace simulator
{
    public abstract class Vehicle
    {
        public string Name;
        public double Speed;

        public Vehicle(string name, double speed)
        {
            Name = name;
            Speed = speed;
        }
        public abstract double calc(double dis);
    }
}
