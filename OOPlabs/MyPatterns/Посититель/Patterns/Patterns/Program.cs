using System;
using System.Collections.Generic;

namespace Patterns
{
    interface IVisitor
    {
        void visit(Admin a);
        void visit(User u);
        void visit(Staff s);
    }

    interface IVisitable
    {
        void Accept(IVisitor v);
    }

    class Admin : IVisitable
    {
        public string Info => "Admin";

        public void Accept(IVisitor v)
        {
            v.visit(this);
        }
    }

    class Staff : IVisitable
    {
        public string Info => "Staff";

        public void Accept(IVisitor v)
        {
            v.visit(this);
        }
    }
    class User : IVisitable
    {
        public string Info => "User";

        public void Accept(IVisitor v)
        {
            v.visit(this);
        }
    }

    class HtmlVisitor : IVisitor
    {
        private string _data = string.Empty;

        public void visit(Admin a)
        {
            _data += $"<p>{a.Info}</p>";
        }

        public void visit(User u)
        {
            _data += $"<p>{u.Info}</p>";
        }

        public void visit(Staff s)
        {
            _data += $"<p>{s.Info}</p>";
        }

        public string Report() => _data;
    }

    class Company
    {
        List<IVisitable> member = new List<IVisitable>();

        public void Add(IVisitable v) => member.Add(v);
        public void remove(IVisitable v) => member.Remove(v);

        public void Accept(IVisitor v)
        {
            foreach (var p in member)
            {
                p.Accept(v);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var c = new Company();
            c.Add(new Admin());
            c.Add(new User());
            c.Add(new Staff());

            var html = new HtmlVisitor();
            c.Accept(html);
            Console.WriteLine(html.Report());
        }
    }
}
