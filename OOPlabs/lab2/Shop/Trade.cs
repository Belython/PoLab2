using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    public class Trade
    { 
        public List<Shop> shops = new List<Shop>();

        public void addShop(Shop shop)
        {
            shops.Add(shop);
        }

        public Shop GetCheapProduct(Product product)
        {
            double minprice = double.MaxValue;
            int index = 0;
            for (int i = 0; i < shops.Count; i++)
            {
                if (minprice > shops[i].CheapProduct(product))
                {
                    minprice = shops[i].CheapProduct(product);
                    index = i;
                }
            }
            if (minprice == double.MaxValue)
            {
                throw  new ExceptionShop.ProductNotFoundException();
            }
            else
            {
                return shops[index];
            }
        }

        public string BuyProduct(List<Product> product)
        {
            double minprice = double.MaxValue;
            int index = 0;
            for (int i = 0; i < shops.Count; i++)
            {
                double minshops = shops[i].BuyProducts(product);
                if (minprice > minshops)
                {
                    minprice = minshops;
                    index = i;
                }
            }
            if (minprice == double.MaxValue)
            {
                throw new ExceptionShop.ConsignmentNotFoundException();
            }
            else
            {
                return shops[index].name;
            }
        }
    }
}
