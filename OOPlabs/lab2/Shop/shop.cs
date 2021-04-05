using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace Shop
{
    public class Shop
    {
        private int id;
        public string name;
        public string adres;
        private List<Product> prodList = new List<Product>();
        public Shop(int id, string name, string adres)
        {
            this.id = id;
            this.name = name;
            this.adres = adres;
        }

        public void addProduct(Product prod)
        {
            prodList.Add(prod);
        }

        public void addProduct(Product prod, double price)
        {
            if (price < 0)
            {
                throw new ExceptionShop.PriceException();
            }

            foreach (var i in prodList)
            {
                if (i.Id == prod.Id)
                {
                    i.Price = price;
                }
            }
        }

        public KeyValuePair<bool, double> TryGetCheapProduct(Product prod)
        {
            bool flag = false;
            double price = 0;

            var cheapProduct = prodList.Find(item => item.Id == prod.Id);
            if (cheapProduct != null)
            {
                flag = true;
                price = cheapProduct.Price;
            }

            return new KeyValuePair<bool, double>(flag, price);
        }
        public double CheapProduct(Product prod)
        {
            double minprice = double.MaxValue;
            if (TryGetCheapProduct(prod).Key)
            {
                if (TryGetCheapProduct(prod).Value < minprice)
                {
                    minprice = TryGetCheapProduct(prod).Value;
                }
            }
            return minprice;
        }

        public Dictionary<string, int> SumProduct(double sum)
        {
            Dictionary<string, int> check = new Dictionary<string, int>();
            foreach (var prodinshop in prodList)
            {
                if (prodinshop.Price <= sum)
                {
                    int count = (int)(sum / prodinshop.Price);
                    check.Add(prodinshop.Name, count);
                }
            }
            return check;
        }

        public bool TryGetBuyProducts(List<Product> product)
        {
            bool flag = true;
            foreach (var prodinshop in prodList)
            {
                foreach (var transfprod in product)
                {
                    if (prodinshop.Id == transfprod.Id && prodinshop.Count < transfprod.Count)
                    {
                        flag = false;
                        return flag;
                    }
                    
                }
            }

            return flag;
        }

        public double BuyProducts(List<Product> product)
        {
            double check = 0;
            if (!TryGetBuyProducts(product))
            {
                return double.MaxValue;
            }
            foreach (var prodinshop in prodList)
            {
                foreach (var transfprod in product)
                {
                    if (prodinshop.Id == transfprod.Id)
                    {
                        check += transfprod.Count * prodinshop.Price;
                        prodinshop.Count -= prodinshop.Count;
                    }
                }
            }

            return check;
        }
    }
}
