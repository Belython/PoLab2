using System;

namespace BANks
{
    public class DebitAccount : Account
    {
        public double SumPersent;

        public double Percent;


        public DebitAccount(Bank bank, Person person, double persent, double maxTransSum)
            : base(bank, person)
        {
            SumPersent = 0;
            Percent = persent;
            MaxTransSum = maxTransSum;

        }
        public override Trancation withdrawals(Person person, double sum)
        {
            if (sum <= ResSum && person.Reliable)
            {
                ResSum -= sum;
                TrancationOperation transaction = new TrancationOperation(this, -sum);
                bank.Trancations.Add(transaction);
                return transaction;
            }
            else
            {
                if (sum <= ResSum  && sum <= MaxTransSum)
                {
                    ResSum -= sum;
                    TrancationOperation transaction = new TrancationOperation(this, -sum);
                    bank.Trancations.Add(transaction);
                    return transaction;
                }
                else
                {
                    throw new Exception("sum > ResSum or person not reliable");
                };
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
            if (sum <= ResSum && person.Reliable)
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
                if (sum <= MaxTransSum && sum <= ResSum)
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