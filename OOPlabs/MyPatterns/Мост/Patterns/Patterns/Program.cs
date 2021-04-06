using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{
    interface IConsole
    {
        void ExucuteCommand(string cmd);
    }

    class Console1 : IConsole
    {
        public void ExucuteCommand(string cmd)
        {
            Console.WriteLine($"Console 1: {cmd}");
        }
    }

    class Console2 : IConsole
    {
        public void ExucuteCommand(string cmd)
        {
            Console.WriteLine($"Console 2: {cmd}");
        }
    }

    abstract class Joystick
    {
        protected IConsole _console;
        public void ChangeConsole(IConsole console)
        {
            _console = console;
        }

        public void SendX()
        {
            _console.ExucuteCommand("x");
        }

        public void SendL1()
        {
            _console.ExucuteCommand("L1");
        }
    }

    class SimpleJoystick : Joystick
    {

    }

    class SmartJoystick : Joystick
    {
        public void SmartButton()
        {
            _console.ExucuteCommand("L1");
            _console.ExucuteCommand("X");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Console1();
            ;

            var smart = new SmartJoystick();
            smart.ChangeConsole(c1);
            smart.SmartButton();

            var c2 = new Console2();
            smart.ChangeConsole(c2);
            smart.SmartButton();
        }
    }
}
