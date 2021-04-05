package ru.billing.stocklist;

import java.util.Date;

public class FoodItem extends GenericItem {
    private Date dateOfIncome;
    private short expires;
    public void setExpires(short expires)
    {
        this.expires = expires;
    }
    public short getExpires()
    {
        return this.expires;
    }
    public void setDateOfIncome(Date dateOfIncome)
    {
        this.dateOfIncome = dateOfIncome;
    }
    public Date getDateOfIncome()
    {
        return this.dateOfIncome;
    }
    public FoodItem(String name, float price, FoodItem analog, Date date, short expires)
    {
        this.setName(name);
        this.setPrice(price);
        this.setAnalog(analog);
        this.setDateOfIncome(date);
        this.setExpires(expires);
    }
    public FoodItem(String name, float price, short expires)
    {
        this.setName(name);
        this.setPrice(price);
        this.setExpires(expires);
        new FoodItem(name, price, (FoodItem) this.getAnalog(), this.getDateOfIncome(), this.getExpires());
    }
    public FoodItem(String name)
    {
        this.setName(name);
        new FoodItem(name, this.getPrice(), (FoodItem) this.getAnalog(), this.getDateOfIncome(), this.getExpires());

    }

    @Override
    public void printAll() {
        super.printAll();
        System.out.printf("expires: %d , dateOfIncome: %tT%n \n",expires, dateOfIncome);
    }
    public boolean equals(Object o)
    {
        return super.equals(o);
    }
}
