package ru.billing.client;

import ru.billing.stocklist.Category;
import ru.billing.stocklist.FoodItem;
import ru.billing.stocklist.GenericItem;
import ru.billing.stocklist.ItemCatalog;

import java.util.Date;

public class Main
{
    public static void main(String[] args)
    {
        ItemCatalog shop = new ItemCatalog();
        GenericItem bread = new GenericItem("Bread", 15.2F, Category.FOOD);
        GenericItem milk = new GenericItem("Milk", 40.3F, Category.FOOD);
        GenericItem garlic = new GenericItem("Garlic", 9.15F, Category.FOOD);
        GenericItem carrot = new GenericItem("Carrot", 11.25F, Category.FOOD);
        GenericItem potato = new GenericItem("Potato", 15.56F, Category.FOOD);
        GenericItem sugar = new GenericItem("Sugar", 150.9F, Category.FOOD);
        GenericItem tomato = new GenericItem("Tomato", 35.78F, Category.FOOD);
        GenericItem meat = new GenericItem("Meat", 250.36F, Category.FOOD);
        GenericItem chicken = new GenericItem("Chicken", 99.27F, Category.FOOD);
        GenericItem candy = new GenericItem("Candy", 87.95F, Category.FOOD);
        shop.addItem(bread);
        shop.addItem(milk);
        shop.addItem(garlic);
        shop.addItem(carrot);
        shop.addItem(potato);
        shop.addItem(sugar);
        shop.addItem(tomato);
        shop.addItem(meat);
        shop.addItem(chicken);
        shop.addItem(candy);


        long begin = new Date().getTime();
        for(int i = 0; i < 100000; i++)
        {
            shop.findItemByID(8);
        }
        long end = new Date().getTime();
        System.out.println("In HashMap: "+(end-begin));

        begin = new Date().getTime();
        for(int i = 0; i < 100000; i++)
        {
            shop.findItemByIDAL(8);
        }
        end = new Date().getTime();
        System.out.println("In ArrayList: "+(end-begin));

        CatalogLoader loader = new CatalogStubLoader();
        loader.load(shop);

    }
}
