using System;
using System.Collections.Generic;

namespace BANks
{
    public abstract class Trancation
    {
        protected static int NEXT_ID = 0;
        public int id;
        protected double summ;
        protected bool isCanseld = false;

        public abstract void undoTracation();

    }
}