namespace BANks
{
    public class ConcreteBuilder : IPerson
    {
        private Person person = new Person();

        public ConcreteBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            person = new Person();
        }
        public void BuildName(string name)
        {
            person.Name = name;
        }

        public void BuildSecondName(string secondname)
        {
            person.SecondName = secondname;
        }

        public void BuildAdres(string adres)
        {
            person.Adres = adres;
        }

        public void BuildPasportID(string pasportid)
        {
            person.PasportID = pasportid;
        }

        public Person GetPerson()
        {
            Person result = person;
            Reset();
            return result;
        }
    }
}