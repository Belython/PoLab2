class FirstClass {
    Integer aInteger
    Double aDouble
    Short aShort
    FirstClass(Integer a, Double b, Short c)
    {
       aInteger = a
       aDouble = b
       aShort = c
    }
    void print()
    {
        println(aInteger + " " + aDouble + " " + aShort)
    }

    Integer retInteger(arg)
    {
        Integer a = arg
    }
    int retInt(arg)
    {
        Integer a = arg
    }
}
