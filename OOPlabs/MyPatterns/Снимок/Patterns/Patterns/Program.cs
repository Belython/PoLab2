using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{
    class Hero
    {
        public int _bullets = 10;
        public int _lives = 5;

        public void Shot()
        {
            if (_bullets > 0)
            {
                --_bullets;
            }
            else
            {
                throw new Exception("Error");
            }
        }

        public HeroMemento Save()
        {
            return new HeroMemento(_bullets, _lives);
        }


        public void Resotre(HeroMemento moMemento)
        {
            _bullets = moMemento._bullets;
            _lives = moMemento._lives;
        }
    }

    class HeroMemento
    {
        public int _bullets { get; }
        public int _lives { get; }

        public HeroMemento(int bullets, int lives)
        {
            _bullets = bullets;
            _lives = lives;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var hero = new Hero();
            var history = new Stack<HeroMemento>();
            hero.Shot();
            hero.Shot();
            history.Push(hero.Save());
            hero.Shot();
            hero.Shot();
            hero.Shot();
            hero.Shot();
            hero.Shot();
            hero.Shot();
            hero.Shot();
            hero.Shot();
            hero.Resotre(history.Pop());
            hero.Shot();
            hero.Shot();
            hero.Shot();
            hero.Shot();
            hero.Shot();
            hero.Shot();
            hero.Shot();
            hero.Shot();
        }
    }
}
