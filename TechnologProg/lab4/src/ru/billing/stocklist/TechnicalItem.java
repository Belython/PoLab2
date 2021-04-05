package ru.billing.stocklist;

public class TechnicalItem extends GenericItem
{
    private short warrantyTime;
    public void setWarrantyTime(short warrTime)
    {
        warrantyTime = warrTime;
    }
    public short getWarrantyTime()
    {
        return warrantyTime;
    }
    @Override
    public void printAll() {
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
        String obj = this.getName() + " " + this.getId() + " "  + this.getPrice() + " " + this.getCategory() + " " + this.getWarrantyTime();
        return obj;
    }
    public Object cloneAnalog()
    {
        TechnicalItem clone = new TechnicalItem();
        clone.setAnalog(this.getAnalog());
        return clone;
    }
}
