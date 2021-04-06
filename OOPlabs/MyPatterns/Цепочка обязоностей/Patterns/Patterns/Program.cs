using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{

    class Program
    {
        interface ITransfer
        {
            ITransfer Successor { get; set; }

            void Transfer(double money);
        }

        abstract class PaymentMethod : ITransfer
        {
            public PaymentMethod(double money)
            {
                _money = money;
            }
            protected double _money;
            public ITransfer Successor { get; set; }

            protected abstract void SelfTransfer(double money);

            public void Transfer(double money)
            {
                if (_money < money)
                {
                    if (Successor != null)
                    {
                        Successor.Transfer(money);
                    }
                    else
                    {
                        throw new Exception("Недостаточно средств");
                    }
                }
                else
                {
                    SelfTransfer(money);
                }
            }
        }

        class TinfoffCard : PaymentMethod
        {
            public string Number { get; }

            public TinfoffCard(string number, double money) : base(money)
            {
                Number = number;
            }

            protected override void SelfTransfer(double money)
            {
                _money -= money;
                Console.WriteLine($"перевели {money} с карты Tinkoff");
            }
        }

        class SberCard : PaymentMethod
        {
            public string Number { get; }
            public SberCard(string number, double money) : base(money)
            {
                Number = number;
            }

            protected override void SelfTransfer(double money)
            {
                _money -= money;
                Console.WriteLine($"перевели {money} с карты SberCard");
            }
        }

        static void Main(string[] args)
        {
            ITransfer t1 = new TinfoffCard("1", 1000);
            ITransfer t2 = new TinfoffCard("13134", 5888);
            ITransfer s = new SberCard("54", 5896321);

            ITransfer handler = t1;
            t1.Successor = s;
            s.Successor = t2;

            handler.Transfer(1001);

        }
    }
}
