using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class ExceptionShop : System.Exception
    {
        public ExceptionShop(string message)
            : base(message)
        { }

        public class PriceException : ExceptionShop
        {
            public PriceException()
                : base("Price < 0")
            { }
        }
        public class CountException : ExceptionShop
        {
            public CountException()
                : base("Count < 0")
            { }
        }
        public class ProductNotFoundException : ExceptionShop
        {
            public ProductNotFoundException()
                : base("Product not found")
            { }
        }
        public class ConsignmentNotFoundException : ExceptionShop
        {
            public ConsignmentNotFoundException()
                : base("consignment not found")
            { }
        }

    }
}
