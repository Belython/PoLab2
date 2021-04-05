using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Shop
{
    public class Product
    {
        public string Name;
        public int Id;
        public int Count;
        public double Price; 
        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Product(Product prod)
        {
            Id = prod.Id;
            Name = prod.Name;
        }
        public Product(Product prod, int count, double price)
        {
            Id = prod.Id;
            Name = prod.Name;
            if (count < 0)
            {
                throw new ExceptionShop.CountException();
            }

            if (price < 0)
            {
                throw new ExceptionShop.PriceException();
            }
            Price = price;
            Count = count;
        }
        public Product(Product prod, int count)
        {
            Id = prod.Id;
            Price = prod.Price;
            Count = count;
        }

    }
}
