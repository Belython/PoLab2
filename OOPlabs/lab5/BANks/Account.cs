using System.Collections.Generic;

namespace BANks
{
    public abstract class Account : IAccount
    {
        private static int NEXT_ID = 0;
        public int id;

        public double ResSum;
        public double MaxTransSum;
        protected Bank bank;

        public List<Account> accounts = new List<Account>();

        public List<Account> GetAccounts()
        {
            return accounts;
        }

        public Account(Bank banks, Person person)
        {
            id = NEXT_ID;
            NEXT_ID++;
            accounts.Add(this);
        }

        public void SetBank(Bank banks)
        {
            bank = banks;
        }

        public Bank GetBank()
        {
            return bank;
        }

        public abstract Trancation withdrawals(Person person, double sum);
        public abstract Trancation refill(double sum);
        public abstract Trancation transfer(Person person, double sum, int AccountID);
        public abstract Account ShowDayPersent();
        public abstract Account ShowMounthPersent();
    }
}