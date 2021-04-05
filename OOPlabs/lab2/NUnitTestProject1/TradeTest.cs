using NUnit.Framework;
using Shop;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    [TestFixture]
    public class TradeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheapProducttest()
        {
            Shop.Shop shop1 = new Shop.Shop(1, "Lenta", "Park Victory");
            Shop.Shop shop2 = new Shop.Shop(2, "Diksi", "40 year pobed");
            Shop.Shop shop3 = new Shop.Shop(3, "pytcherochka", "strret mira");

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

            shop1.addProduct(new Product(prod1), 50, 100);
            shop2.addProduct(new Product(prod1), 100, 65);
            shop3.addProduct(new Product(prod1), 10, 16);

            Trade trade = new Trade();
            trade.addShop(shop1);
            trade.addShop(shop2);
            trade.addShop(shop3);
            var actual = trade.CheapProduct(prod1);
            var excexpected = "pytcherochka";
            Assert.AreEqual(excexpected, actual);
        }

        [Test]
        public void BuyProducttest()
        {
            Shop.Shop shop1 = new Shop.Shop(1, "Lenta", "Park Victory");
            Shop.Shop shop2 = new Shop.Shop(2, "Diksi", "40 year pobed");
            Shop.Shop shop3 = new Shop.Shop(3, "pytcherochka", "strret mira");

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

            shop1.addProduct(new Product(prod1), 50, 100);
            shop2.addProduct(new Product(prod1), 100, 65);
            shop3.addProduct(new Product(prod1), 10, 16);
            shop1.addProduct(new Product(prod2), 50, 100);
            shop2.addProduct(new Product(prod2), 100, 65);
            shop3.addProduct(new Product(prod2), 10, 16);

            List<Product> buy = new List<Product>();
            buy.Add(new Product(prod1, 1));
            buy.Add(new Product(prod2, 1));
            Trade trade = new Trade();
            trade.addShop(shop1);
            trade.addShop(shop2);
            trade.addShop(shop3);
            var actual = trade.BuyProduct(buy);
            var excexpected = "pytcherochka";
            Assert.AreEqual(excexpected, actual);
        }
    }
}