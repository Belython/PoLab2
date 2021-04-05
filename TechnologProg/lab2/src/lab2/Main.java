package lab2;

import java.time.LocalDate;
import java.util.Date;

public class Main {
    public static void main(String[] args) {
        GenericItem table = new GenericItem();
        table.price = 12.015F;
        table.name = "TABLE";
        table.ID = 0;
        table.category = Category.PRINT;
        table.printAll();
        GenericItem phone = new GenericItem();
        phone.price = 120.8109F;
        phone.name = "PHONE";
        phone.ID = 1;
        phone.category = Category.FOOD;
        phone.printAll();
        GenericItem laptop = new GenericItem();
        laptop.price = 995.5F;
        laptop.name = "LAPTOP";
        laptop.ID = 2;
        laptop.category = Category.DRESS;
        laptop.printAll();
        FoodItem cake = new FoodItem();
        cake.category = Category.FOOD;
        cake.ID = 5;
        cake.price = 0.12F;
        cake.name = "CAKE";
        Date date = new Date();
        cake.dateOfIncome = date;
        cake.expires = 125;
        FoodItem pancakes = new FoodItem();
        pancakes.category = Category.FOOD;
        pancakes.ID = 10;
        pancakes.price = 0.12F;
        pancakes.name = "CAKE";
        Date date1 = new Date();
        cake.dateOfIncome = date1;
        cake.expires = 135;
        TechnicalItem computer = new TechnicalItem();
        computer.ID = 6;
        computer.price = 5000.12F;
        computer.name = "COMPUTER";
        computer.warrantyTime = 365;

        GenericItem [] mas = {cake, computer};
        for (GenericItem it : mas)
        {
            it.printAll();
        }
        System.out.println(table.equals(phone));
        System.out.println(table.equals(computer));
        System.out.println(cake.equals(pancakes));
        System.out.println(cake.equals(cake.clone()));
        System.out.println(cake.toString());
    }
}
