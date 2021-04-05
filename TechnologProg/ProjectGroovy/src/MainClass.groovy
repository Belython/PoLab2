FirstClass aClass = new FirstClass(3, (Double)5.5, (Short)2)
aClass.print()
aClass.setaInteger(4)
aClass.print()
Binding a = new Binding()
a.setVariable("aClassint", aClass.aInteger = 50)
a.setVariable("aClassdouble", aClass.aDouble = 50.54)
a.setVariable("aClassshort", aClass.aShort = 20)
System.out.println(a.getVariable("aClassint") + " " + a.getVariable("aClassdouble") + " " + a.getVariable("aClassshort"))
aClass.print()
System.out.println(aClass.getaInteger())
aClass.setaInteger(4)
System.out.println(aClass.getaInteger())
String s = new String("safsf")
System.out.println(s instanceof Integer)
def c
c = "name"
println c
c = 8
println c
def b = 2
println b
b = "wqt"
println b
//int f = 2
//f = "saf"
p12 = aClass.retInteger(12)
println p12

println aClass.retInteger(null)
//println aClass.retInt(null)

def b1 = new BigDecimal(50.5)
def b2 = new BigDecimal(50.5)
println b1.getMetaClass()
println b2.getMetaClass()
println b1.equals(b2)
println b1.add(b2)
println b1.divide(b2)
println b1.multiply(b2)
println b1+ b2
println b1 / b2
println b1 * b2

name = 5
name = "f"
name = "First"
println name.getClass().getName()
name = "f"
name = "First"
name = 5
println name.getClass().getName()
name = "First"
name = 5
name = 'f'
println name.getClass().getName()

Date date1 = new Date(2015, 1, 28)
Date date2 = new Date(2015, 0, 31)
use(groovy.time.TimeCategory) {
    println date1 - date2
    date1 = date1 - 1.month
    println date1
    date1 = date1 + 1.month
    println date1
    date1 = date1 + 1.day
    println date1
}

def del={number1, number2 ->
    number1 / number2
}
def min={number1, number2 ->
    number1 - number2
}
def delandmin={number1, number2, number3 ->
    min(del(number1, number2), number3)
}
println del(1, 2)
println min(1, 2)
println delandmin(1, 2, 0.2)