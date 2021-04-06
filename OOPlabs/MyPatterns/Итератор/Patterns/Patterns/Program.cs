using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{
    class Program
    {
        class Book
        {
        }

        interface IBookIterator
        {
            bool HasNext();
            Book Next();
        }

        interface IBookEnum
        {
            int Count { get; }

            Book Take(int index);

            IBookIterator Iterator();
        }

        class BookIterator : IBookIterator
        {
            protected IBookEnum _lib;
            protected int _index;
            public BookIterator(IBookEnum lib)
            {
                _lib = lib;
                _index = 0;
            }
            public bool HasNext()
            {
                return _index < _lib.Count;
            }

            public Book Next()
            {
                return _lib.Take(_index++);
            }
        }

        class Library : IBookEnum
        {
            protected  List<Book> _books = new List<Book>();
            public int Count { get; }
            public IBookIterator Iterator()
            {
                return new BookIterator(this);
            }

            public Book Take(int index)
            {
                return _books[index];
            }
        }

        static void Main(string[] args)
        {
            var lib = new Library();

            var it = lib.Iterator();
            while (it.HasNext())
            {
                var b = it.Next();
                Console.WriteLine(b);
            }

        }
    }
}
