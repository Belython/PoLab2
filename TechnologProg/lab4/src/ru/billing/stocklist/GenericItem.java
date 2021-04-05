package ru.billing.stocklist;

public class GenericItem {
    private int ID;
    private String name;
    private float price;
    private GenericItem analog;
    private Category category = Category.GENERAL;
    private static int currentID = 0;
    public int getId()
    {
        return this.ID;
    }
    public void setName(String name)
    {
        this.name = name;
    }
    public String getName()
    {
        return this.name;
    }
    public void setPrice(float Price)
    {
        this.price = Price;
    }
    public float getPrice()
    {
        return this.price;
    }
    public void setCategory(Category category)
    {
        this.category = category;
    }
    public Category getCategory()
    {
        return this.category;
    }
    public void setAnalog(GenericItem analog)
    {
        this.analog = analog;
    }
    public GenericItem getAnalog()
    {
        return this.analog;
    }
    public GenericItem(String name, float price, Category category)
    {
        this.name = name;
        this.price = price;
        this.category = category;
        this.ID = GenericItem.currentID++;
    }
    public GenericItem(String name, float price, GenericItem analog)
    {
        this.name = name;
        this.price = price;
        this.analog = analog;
        this.ID = GenericItem.currentID++;
    }
    public GenericItem()
    {
        this.ID = GenericItem.currentID++;
    }

    public void printAll(){
        System.out.printf("ID: %d , Name: %-20s , price:%5.2f, category: %s  \n",ID,name,price, category);
    }
    public boolean equals(Object o)
    {
        if(this.getClass() == o.getClass())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public Object clone()
    {
        GenericItem clone = new GenericItem();
        clone = this;
        return clone;
    }
    public String toString( )
    {
        String obj = this.name + " " + this.ID + " "  + this.price + " " + this.category;
        return obj;
    }
    public Object cloneAnalog()
    {
        GenericItem clone = new GenericItem();
        clone = this.analog;
        return clone;
    }
}
