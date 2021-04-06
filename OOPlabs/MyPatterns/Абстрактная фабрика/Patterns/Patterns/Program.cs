using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{
    public interface IHit
    {
        void Hit(Hero h);
    }
    public interface IMovement
    {
        void Move(Hero h);
    }
    public class Hero
    {
        public IHit Weapon { get; }
        public IMovement Movement { get; }

        public Hero(IHeroFactory fact)
        {
            Weapon = fact.GetHit();
            Movement = fact.GetMovement();
        }
    }

    public class Sword : IHit
    {
        public void Hit(Hero h)
        {
            Console.WriteLine($"Удар мечом по {h}");
        }
    }

    public class Bow : IHit
    {
        public void Hit(Hero h)
        {
            Console.WriteLine($"Выстрел по {h}");
        }
    }

    public class Staff : IHit
    {
        public void Hit(Hero h)
        {
            Console.WriteLine($"Кастуем посохом по {h}");
        }
    }

    public class Run : IMovement
    {
        public void Move(Hero h)
        {
            Console.WriteLine($"Герой {h} переходит");
        }
    }

    public class Teleport : IMovement
    {
        public void Move(Hero h)
        {
            Console.WriteLine($"Герой {h} летит");
        }
    }

    public interface IHeroFactory
    {
        IHit GetHit();
        IMovement GetMovement();
    }

    public class ClassicElfFactoey : IHeroFactory
    {
        public IHit GetHit()
        {
            return new Bow();
        }

        public IMovement GetMovement()
        {
            return new Run();
        }
    }
    public class MageFactoey : IHeroFactory
    {
        public IHit GetHit()
        {
            return new Staff();
        }

        public IMovement GetMovement()
        {
            return new Teleport();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ClassicElfFactoey());
        }
    }
}
