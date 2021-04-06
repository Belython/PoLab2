using System;
using System.Collections.Generic;

namespace Patterns
{

    abstract class Mediator
    {
        public abstract void Send(string msg, Participant p);
    }

    abstract class Participant
    {
        protected Mediator _mediator;

        protected Participant(Mediator m)
        {
            _mediator = m;
        }

        public void Send(string msg)
        {
            _mediator.Send(msg, this);
        }

        public abstract void Receive(string msg);
    }

    class Cstomer : Participant
    {
        public Cstomer(Mediator m) : base(m)
        {
        }

        public override void Receive(string msg)
        {
            Console.WriteLine($"Сообщение заказчику: {msg}");
        }
    }

    class Developer : Participant
    {
        public Developer(Mediator m) : base(m)
        {
        }

        public override void Receive(string msg)
        {
            Console.WriteLine($"Сообщение разработчику: {msg}");
        }
    }

    class Tester : Participant
    {
        public Tester(Mediator m) : base(m)
        {
        }

        public override void Receive(string msg)
        {
            Console.WriteLine($"Сообщение тестировщику: {msg}");
        }
    }

    class Manager : Mediator
    {
        public Cstomer Cstomer { get; set; }
        public Developer Developer { get; set; }
        public Tester Tester { get; set; }
        public override void Send(string msg, Participant p)
        {
            if (Tester == p)
            {
                Cstomer.Send(msg);
            }
            else if (Developer == p)
            {
                Tester.Send(msg);
            }
            else if (Cstomer == p)
            {
                Developer.Send(msg);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();
            var customer = new Cstomer(manager);
            var dev = new Developer(manager);
            var test = new Tester(manager);

            manager.Tester = test;
            manager.Developer = dev;
            manager.Cstomer = customer;

            customer.Send("add inf");
            dev.Send("sucsecfull");
            test.Send("OK");
        }
    }
}
