using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    class ExceptionSimulator : System.Exception
    {
        public ExceptionSimulator(string message)
            : base(message)
        { }

        public class EmptyException : ExceptionSimulator
        {
            public EmptyException()
                : base("Empty race")
            { }
        }
    }
}
