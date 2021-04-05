using System;
using System.Collections.Generic;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop1 = new Shop(1, "Lenta", "Park Victory");
            Shop shop2 = new Shop (2,"Diksi", "40 year pobed");
            Shop shop3 = new Shop(3,"pytcherochka", "strret mira");

            Product prod1 = new Product(1,"potate");
            Product prod2 = new Product(2,"cabidge");
            Product prod3 = new Product( 3,"pencil");
            Product prod4 = new Product(4,"pen");
            Product prod5 = new Product(5,"chair");
            Product prod6 = new Product( 6,"book");
            Product prod7 = new Product( 7,"paper");
            Product prod8 = new Product(8, "fish");
            Product prod9 = new Product(9,"met");
            Product prod10 = new Product( 10,"bed");

            try
            {
                shop1.addProduct(new Product(prod1, 10, 100));
                shop1.addProduct(new Product(prod2, 10, 20));
                shop1.addProduct(new Product(prod3, 10, 20));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            foreach (var i in shop1.SumProduct(100))
            {
                Console.WriteLine(i.Value + " " + i.Key);
            }

            List<Product> buy = new List<Product>();
            buy.Add(new Product(prod1, 1));
            buy.Add(new Product(prod2, 1));
            Console.WriteLine(shop1.BuyProducts(buy));

            try
            {
                shop2.addProduct(new Product(prod1, 100, 12));
                shop2.addProduct(new Product(prod2, 10, 20));
                shop2.addProduct(new Product(prod3, 10, 20));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                shop3.addProduct(new Product(prod1, 10, 16));
                shop3.addProduct(new Product(prod2, 10, 20));
                shop3.addProduct(new Product(prod3, 10, 20));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Trade trade = new Trade();
            trade.addShop(shop1);
            trade.addShop(shop2);
            trade.addShop(shop3);
            Console.WriteLine(trade.BuyProduct(buy));
            var cheapproduct = trade.GetCheapProduct(prod1);
            Console.WriteLine(cheapproduct.name);
            Console.ReadKey();
        }
    }
}
