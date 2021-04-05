package lab3;

import java.io.IOException;
import java.time.LocalDate;
import java.util.Date;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) throws IOException {
        FoodItem pancakes = new FoodItem("CAKE", 8.5F, (short) 12) ;
        pancakes.printAll();
        FoodItem pancakes1 = new FoodItem("CAKE1", 8.51F, (short) 121) ;
        pancakes1.printAll();
        FoodItem pancakes2 = new FoodItem("CAKE2", 8.52F, (short) 122) ;
        pancakes2.printAll();
        Integer intArr[]={10,20,15};
        Float[] floatArr = new Float[5];
        for(int i = 0; i < 5; i++)
        {
            floatArr[i] = (float)(Math.random()*10);
            System.out.println(floatArr[i]);
        }
        U0901WorkArray intA = new U0901WorkArray(intArr);
        U0901WorkArray floatA = new U0901WorkArray(floatArr);
        System.out.println(intA.sum());
        System.out.println(floatA.sum());
        String intStr[] = {"cake", "fas"};
        //U0901WorkArray strA = new U0901WorkArray(intStr);
        String line = "Конфеты ’Маска’;45;120";
        String[] item_fld;
        item_fld = line.split(";");
        for(var it : item_fld)
        {
            System.out.println(it);
        }
        FoodItem candy = new FoodItem(item_fld[0], Float.parseFloat(item_fld[1]), Short.parseShort(item_fld[2]));
        candy.printAll();
    }
}
