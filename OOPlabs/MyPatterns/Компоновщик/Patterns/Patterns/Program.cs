using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;

namespace Patterns
{
    interface INode
    {
        string Name { get; }
        void Display();
    }

    class File : INode
    {
        public File(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public void Display()
        {
            Console.WriteLine($"File: {Name}");
        }
    }

    class Directory : INode
    {
        List<INode> children = new List<INode>();
        public Directory(string name)
        {
            Name = name;
        }
        public string Name { get; }

        public void Add(INode node)
        {
            children.Add(node);
        }
        public void Remove(INode node)
        {
            children.Remove(node);
        }
        public void Display()
        {
            Console.WriteLine($"Direcoty: {Name}");
            foreach (var node in children)
            {
                node.Display();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var fs = new Directory("/");
            var diskC = new Directory("Local Drive C");
            fs.Add(diskC);

            var txt = new File("data.txt");
            diskC.Add(txt);
            var png = new File("im.png");
            diskC.Add(png);

            png.Display();
            Console.WriteLine();
            fs.Display();

        }
    }
}
