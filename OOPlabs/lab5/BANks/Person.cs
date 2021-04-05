using System.Collections.Generic;

namespace BANks
{
    public class Person
    {
        public static int NEXT_ID = 0;
        public int id;
        public string Name;
        public string SecondName;
        public string Adres;
        public string PasportID;
        public List<Account> Accounts = new List<Account>();
        public bool Reliable = false;

        public Person()
        {
            id = NEXT_ID;
            NEXT_ID++;
        }

        public void MakeReliable(string adress, string pasportid)
        {
            Adres = adress;
            PasportID = pasportid;
            Reliable = true;
        }

        public void CheckReliable()
        {
            if ((Adres == "") || (PasportID == ""))
            {
                Reliable = false;
            }
            else
            {
                Reliable = true;
            }
        }

    }
}