using System;

namespace BANks
{
    public class TrancationTransfer : Trancation
    {
        Account first;
        Account second;

        public TrancationTransfer(Account one, Account two, double sum)
        {
            first = one;
            second = two;
            summ = sum;
            id = NEXT_ID;
            NEXT_ID++;
            one.GetBank().Trancations.Add(this);
            two.GetBank().Trancations.Add(this);
        }

        public override void undoTracation()  
        {
            if (this.isCanseld)
            {
                throw new Exception("Trancations canseled");
            }

            var a = first.accounts.Find(x => x.id == first.id);
            var b = second.accounts.Find(x => x.id == second.id);
            a.ResSum += summ;
            b.ResSum -= summ;
            isCanseld = true;
        }
    }
}