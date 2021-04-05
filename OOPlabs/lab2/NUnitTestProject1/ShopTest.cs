using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shop;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BuyProductsTest()
        {

            Product prod1 = new Product(1, "potate");
            Product prod2 = new Product(2, "cabidge");
            Product prod3 = new Product(3, "pencil");
            Product prod4 = new Product(4, "pen");
            Product prod5 = new Product(5, "chair");
            Product prod6 = new Product(6, "book");
            Product prod7 = new Product(7, "paper");
            Product prod8 = new Product(8, "fish");
            Product prod9 = new Product(9, "met");
            Product prod10 = new Product(10, "bed");

            Shop.Shop shop1 = new Shop.Shop(1, "Lenta", "Park Victory");
            Shop.Shop shop2 = new Shop.Shop(2, "Diksi", "40 year pobed");
            Shop.Shop shop3 = new Shop.Shop(3, "pytcherochka", "strret mira");

            shop1.addProduct(new Product(prod1), 50, 100);
            shop1.addProduct(new Product(prod2), 10, 20);
            shop1.addProduct(new Product(prod3), 10, 20);

            List<Product> buy = new List<Product>();
            buy.Add(new Product(prod1, 2));
            buy.Add(new Product(prod2, 3));


            var actual = (shop1.BuyProducts(buy));
            var expected = 260;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SumProductTest()
        {
            Product prod1 = new Product(1, "potate");
            Product prod2 = new Product(2, "cabidge");
            Product prod3 = new Product(3, "pencil");
            Product prod4 = new Product(4, "pen");
            Product prod5 = new Product(5, "chair");
            Product prod6 = new Product(6, "book");
            Product prod7 = new Product(7, "paper");
            Product prod8 = new Product(8, "fish");
            Product prod9 = new Product(9, "met");
            Product prod10 = new Product(10, "bed");

            Shop.Shop shop1 = new Shop.Shop(1, "Lenta", "Park Victory");
            shop1.addProduct(prod1, 50, 1);
            shop1.addProduct(prod3, 100, 1);
            shop1.addProduct(prod5, 50, 2);

            var actual = shop1.SumProduct(100);
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("potate", 50);
            expected.Add("pencil", 100);
            expected.Add("chair", 50);
            Assert.AreEqual(expected, actual);
        }
    }
}