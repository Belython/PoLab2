using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BANks
{
    public class CreditAccount : Account
    {
        public double Comision;
        public double CreditLimit;

        public CreditAccount(Bank bank, Person person, double comision, double limit)
            : base(bank, person)
        {
            Comision = comision;
            CreditLimit = limit;
        }


        public override Trancation withdrawals(Person person,  double sum)
        {
            if (sum <= ResSum + CreditLimit && person.Reliable)
            {
                ResSum -= sum;
                TrancationOperation transaction = new TrancationOperation(this, -sum);
                return transaction;
            }
            else
            {
                if (sum <= ResSum + CreditLimit && sum <= MaxTransSum)
                {
                    ResSum -= sum;
                    TrancationOperation transaction = new TrancationOperation(this, -sum);
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
            return transaction;
        }

        public override Trancation transfer(Person person, double sum, int AccountID)
        {
            Trancation transaction = null;
            if (sum <= ResSum + CreditLimit && person.Reliable)
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
                if (sum <= ResSum + CreditLimit && sum <= MaxTransSum)
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
            if (ResSum < 0)
            {
                ResSum -= Comision;
            }
            return this;
        }

        public override Account ShowMounthPersent()
        {
            if (ResSum < 0)
            {
                ResSum -= Comision;
            }
            return this;
        }

    }
}