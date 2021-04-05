using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BANks
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConcreteBuilder();
            builder.BuildName("Alexander");
            builder.BuildSecondName("Velikdonyy");
            builder.BuildAdres("street");
            builder.BuildPasportID("1815149774");
            var a = builder.GetPerson();
            Console.WriteLine(a.Name + " " + a.SecondName + " " + a.Adres + " " + a.PasportID);
            Dictionary<double, double> dep = new Dictionary<double, double>();
            dep.Add(100, 2);
            dep.Add(200, 3);
            var bank = new Bank(10, 5, 100, 50, dep);
            bank.AddPerson(a);
            bank.CreateDebitAccount(a);
            a.Accounts[0].refill(100);
            foreach (var acc in a.Accounts)
            {
                Console.WriteLine(acc.ResSum);
            }

            bank.undoTrancation(bank.Trancations[0].id);
            foreach (var acc in a.Accounts)
            {
                Console.WriteLine(acc.ResSum);
            }
        }
    }
}
