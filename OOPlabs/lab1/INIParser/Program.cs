using System;

namespace INIParser
{

    class Program
    {
        static void Main(string[] args)
            {
                //Проверка 3 типов + комментарии
                IniParser ini = new IniParser(@"F:\test.ini");
                var stringtest = ini.TryGetString("COMMON", "DiskCachePath");
                Console.WriteLine(stringtest);
                var inttest = ini.TryGetInt("COMMON", "LogXML");
                Console.WriteLine(inttest);
                var doubletest = ini.TryGetDouble("ADC_DEV", "BufferLenSecons");
                Console.WriteLine(doubletest);

                // Проверка на =
                //IniParser ini_2 = new IniParser(@"F:\test2.ini");
                //var notsection = ini_2.TryGetString("COMMON", "DiskCachePath");
                //Console.WriteLine(notsection);
                // Проверка на отсутствие секции
                //IniParser ini_3 = new IniParser(@"F:\test3.ini");
                //var notsection_2 = ini_3.TryGetString("fun", "help");
                //проверка на неверное разрешение
                //IniParser ini_4 = new IniParser(@"F:\test2.txt");
                //проверка на отсутствие файла
                //IniParser ini_5 = new IniParser(@"F:\test4.txt");
                //проверка на не соотвествие видов
                //IniParser ini_6 = new IniParser(@"F:\test.ini");
                //var inttest_2 = ini_6.TryGetInt("COMMON", "DiskCachePath");
                //Console.WriteLine(inttest_2);
                //var doubletest_3 = ini_6.TryGetDouble("COMMON", "DiskCachePath");
                //Console.WriteLine(doubletest_3);
                var str = ini.TryGet<string>("COMMON", "DiskCachePath");
                Console.WriteLine(stringtest);
                var inter = ini.TryGet<int>("COMMON", "LogXML");
                Console.WriteLine(inttest);
                var ddoublet = ini.TryGet<double>("ADC_DEV", "BufferLenSecons");
                Console.WriteLine(doubletest);
                Console.ReadLine();
            }
    }
}
