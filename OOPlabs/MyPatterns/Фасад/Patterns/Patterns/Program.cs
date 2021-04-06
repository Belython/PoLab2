using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;

namespace Patterns
{
    class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Write code ...");
        }
        public void SaveCode()
        {
            Console.WriteLine("Save code ...");
        }
    }

    class Compiler
    {
        public void Compile()
        {
            Console.WriteLine("compiling");
        }
    }

    class Linker
    {
        public void link()
        {
            Console.WriteLine("Linking");
        }
    }

    class Debugger
    {
        public void Execute()
        {
            Console.WriteLine("Executeing");
        }
        public void Stop()
        {
            Console.WriteLine("Stopping");
        }
    }

    class VisualStudioFasad
    {
        private TextEditor _te = new TextEditor();
        private Compiler _compiler = new Compiler();
        private Linker _linker = new Linker();
        private Debugger _debugger = new Debugger();

        public void CreateCode()
        {
            _te.CreateCode();
        }

        public void Save()
        {
            _te.SaveCode();
        }

        public void Run()
        {
            Save();
            _compiler.Compile();
            _linker.link();
            _debugger.Execute();
        }
        public void Stod()
        {
            _debugger.Stop();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ide = new VisualStudioFasad();
            ide.Run();
            ide.Stod();

        }
    }
}
