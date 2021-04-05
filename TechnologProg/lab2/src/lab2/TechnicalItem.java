package lab2;

public class TechnicalItem extends GenericItem
{
    short warrantyTime;
    @Override
    void printAll() {
        super.printAll();
        System.out.printf("warrantyTime: %d \n",warrantyTime);
    }
    public boolean equals(Object o)
    {
        return super.equals(o);
    }
    public Object clone()
    {
        TechnicalItem clone = new TechnicalItem();
        clone = this;
        return clone;
    }
    public String toString( )
    {
        String obj = this.name + " " + this.ID + " "  + this.price + " " + this.category + " " + this.warrantyTime;
        return obj;
    }
    public Object cloneAnalog()
    {
        TechnicalItem clone = new TechnicalItem();
        clone.analog = this.analog;
        return clone;
    }
}
