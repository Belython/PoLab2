using System;

namespace BANks
{
    public class TrancationOperation : Trancation
    {
		Account acc;

        public TrancationOperation(Account one, double sum)
        {
            acc = one;
            summ = sum;
            id = NEXT_ID;
            NEXT_ID++;
            one.GetBank().Trancations.Add(this);
        }

        public override void undoTracation()
        {
            if (this.isCanseld)
            {
                throw new Exception("Trancations canseled");
            }

            var a = acc.accounts.Find(x => x.id == acc.id);

            a.ResSum -= summ;
            isCanseld = true;
        }

    }
}