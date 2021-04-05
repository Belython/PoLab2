package lab3;

import java.util.Date;

public class FoodItem extends GenericItem {
    Date dateOfIncome;
    short expires;
    public FoodItem(String name, float price, FoodItem analog, Date date, short expires)
    {
        this.name = name;
        this.price = price;
        this.analog = analog;
        this.dateOfIncome = date;
        this.expires = expires;
    }
    public FoodItem(String name, float price, short expires)
    {
        this.name = name;
        this.price = price;
        this.expires = expires;
        new FoodItem(name, price, (FoodItem) this.analog, this.dateOfIncome, expires);
    }
    public FoodItem(String name1)
    {
        this.name = name;
        new FoodItem(name, this.price, (FoodItem) this.analog, this.dateOfIncome, this.expires);

    }

    @Override
    void printAll() {
        super.printAll();
        System.out.printf("expires: %d , dateOfIncome: %tT%n \n",expires, dateOfIncome);
    }
    public boolean equals(Object o)
    {
        return super.equals(o);
    }
}
