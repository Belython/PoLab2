using System;

namespace Patterns
{
    abstract class Unit
    {

        public void Turn()
        {
            CollectRes();
            Building();
            if (HsEnemy())
            {
                Attack();
            }
        }

        protected abstract void CollectRes();
        protected abstract void Building();
        protected abstract bool HsEnemy();
        protected abstract void Attack();
    }

    class Human : Unit
    {
        protected override void CollectRes()
        {
            Console.WriteLine("Собираю ресурсы");
        }

        protected override void Building()
        {
            Console.WriteLine("Строю казарму");
        }

        protected override bool HsEnemy()
        {
            return new Random().NextDouble() > 0.6;
        }

        protected override void Attack()
        {
            Console.WriteLine("Стреляю из лука");
        }
    }

    class Orcs : Unit
    {
        protected override void CollectRes()
        {
        }

        protected override void Building()
        {
        }

        protected override bool HsEnemy()
        {
            return true;
        }

        protected override void Attack()
        {
            Console.WriteLine("Атакую рукой");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Aleks = new Human();
            var Matematicka = new Orcs();

            Aleks.Turn();
            Matematicka.Turn();
        }
    }
}
