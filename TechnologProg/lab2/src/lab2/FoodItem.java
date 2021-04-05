package lab2;

import java.util.Date;

public class FoodItem extends GenericItem {
    Date dateOfIncome;
    short expires;

    @Override
    void printAll() {
        super.printAll();
        System.out.printf("expires: %d , dateOfIncome: %tT%n \n",expires, dateOfIncome);
    }
    public boolean equals(Object o)
    {
        return super.equals(o);
    }
    public Object clone()
    {
        FoodItem clone = new FoodItem();
        clone = this;
        return clone;
    }
    public String toString( )
    {
        String obj = this.name + " " + this.ID + " "  + this.price + " " + this.category + " " + this.dateOfIncome + " " + this.expires;
        return obj;
    }
    public Object cloneAnalog()
    {
        FoodItem clone = new FoodItem();
        clone.analog = this.analog;
        return clone;
    }
}
