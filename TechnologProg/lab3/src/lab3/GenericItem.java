package lab3;

public class GenericItem {
    public int ID;
    public String name;
    public float price;
    GenericItem analog;
    public Category category = Category.GENERAL;
    static int currentID = 0;
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

    void printAll(){
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
