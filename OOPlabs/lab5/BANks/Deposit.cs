using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace BANks
{
    public class DepositAccount : Account
    {
        public double SumPersent;
        public double Percent;
        public DateTime DateNow;
        public DateTime Date;
        public Dictionary<double, double> Deposit = new Dictionary<double, double>();
        public DepositAccount(Bank bank, Person person, Dictionary<double, double> deposit, double resSum, DateTime dat)
            : base(bank, person)
        {
            Deposit = deposit;
            DateNow = DateTime.Now;
            Date = dat;
            ResSum = resSum;
            SetSumma(ResSum);
        }

        public void SetSumma(double ResSum)
        {
            foreach (KeyValuePair<double, double> dep in Deposit)
            {
                if (ResSum < dep.Key)
                {
                    Percent = dep.Value;
                    break;
                }
            }
        }

        public override Trancation withdrawals(Person person, double sum)
        {
            if (sum <= ResSum && person.Reliable && DateNow > Date)
            {
                ResSum -= sum;
                TrancationOperation transaction = new TrancationOperation(this, -sum);
                bank.Trancations.Add(transaction);
                return transaction;
            }
            else
            {
                if (sum <= ResSum && sum <= MaxTransSum && DateNow > Date)
                {
                    ResSum -= sum;
                    TrancationOperation transaction = new TrancationOperation(this, -sum);
                    bank.Trancations.Add(transaction);
                    return transaction;
                }
                else
                {
                    throw new Exception("sum > ResSum or person not reliable");
                }
            }
        }

        public override Trancation refill(double sum)
        {
            ResSum += sum;
            TrancationOperation transaction = new TrancationOperation(this, sum);
            bank.Trancations.Add(transaction);
            return transaction;
        }

        public override Trancation transfer(Person person, double sum, int AccountID)
        {
            Trancation transaction = null;
            if (sum <= ResSum && person.Reliable && DateNow > Date)
            {
                ResSum -= sum;
                var a = GetAccounts().Find(item => item.id == AccountID);
                if (a != null)
                {
                    a.ResSum += sum;
                    transaction = new TrancationTransfer(this, a, sum);
                }
            }
            else
            {
                if (sum < MaxTransSum && DateNow > Date)
                {
                    ResSum -= sum;
                    var a = GetAccounts().Find(item => item.id == AccountID);
                    if (a != null)
                    {
                        a.ResSum += sum;
                        transaction = new TrancationTransfer(this, a, sum);
                    }
                }
                else
                {
                    throw new Exception("sum > ResSum or person not reliable");
                }
            }

            if (transaction != null)
            {
                bank.Trancations.Add(transaction);
            }
            return transaction;
        }

        public override Account ShowDayPersent()
        {
            SumPersent += (ResSum * Percent) / 100;
            return this;
        }

        public override Account ShowMounthPersent()
        {
            ResSum += SumPersent;
            SumPersent = 0;
            return this;
        }
    }
}