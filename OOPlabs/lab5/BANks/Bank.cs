using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace BANks
{
    public class Bank
    {
        public List<Person> Persons;
        public List<Account> Accounts;
        public Dictionary<double, double> Deposit;
        public List<Trancation> Trancations;
        public double Persent;
        public double Commision;
        public double Limit;
        public double MaxTransSum;
        public Bank(double commision, double persent, double limit, double maxtranssum, Dictionary<double, double> deposit)
        {
            Persons = new List<Person>();
            Accounts = new List<Account>();
            Trancations = new List<Trancation>();
            Deposit = new Dictionary<double, double>();
            Deposit = deposit;
            Commision = commision;
            Persent = persent;
            Limit = limit;
            MaxTransSum = maxtranssum;
        }

        public void AddPerson(Person person)
        {
            Persons.Add(person);
        }

        public void CreateDebitAccount(Person person)
        {
            var a = Persons.Find(x => x.id == person.id);
            if (a != null)
            {
                var debit = new DebitAccount(this, person, Persent, MaxTransSum);
                person.Accounts.Add(debit);
                Accounts.Add(debit);
                debit.SetBank(this);
            }
            else
            {
                throw new Exception("Person not found");
            }
        }
        public void CreateCreditAccount(Person person)
        {
            var a = Persons.Find(x => x.id == person.id);
            if (a != null)
            {
                var credit = new CreditAccount(this, person, Commision, Limit);
                person.Accounts.Add(credit);
                Accounts.Add(credit);
                credit.SetBank(this);
            }
            else
            {
                throw new Exception("Person not found");
            }
        }
        public void CreateDepositAccount(Person person, double sum, DateTime date)
        {
            var a = Persons.Find(x => x.id == person.id);
            if (a != null)
            {
                var deposit = new DepositAccount(this, person, Deposit, sum, date);
                person.Accounts.Add(deposit);
                Accounts.Add(deposit);
                deposit.SetBank(this);
            }
            else
            {
                throw new Exception("Person not found");
            }
        }

        public void undoTrancation(int id)
        {
            var a = Trancations.Find(x => x.id == id);
            if (a != null)
            {
                a.undoTracation();
            }
            else
            {
                throw new Exception("trancation not found");
            }
        }
    }
}