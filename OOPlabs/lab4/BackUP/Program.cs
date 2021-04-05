using System;
using System.Collections.Generic;
using System.IO;

namespace BackUP
{
    class Program
    {
        static void Main(string[] args)
        {
            BackUp backUp = new BackUp();
            string path = @"F:\test.txt";
            string path2 = @"F:\test2.txt";
            FileInfo fi1 = new FileInfo(path);
            FileInfo fi2 = new FileInfo(path2);
            backUp.AddFileToBackUp(fi1);
            backUp.CreateRestorePoint(false);
            backUp.AddFileToBackUp(fi2);
            backUp.CreateRestorePoint(true);
            //backUp.CreateRestorePoint();
            //backUp.CreateRestorePoint();
            //backUp.SetRestrictionLength(1);
            //backUp.CheckAllRestrictions();
            //backUp.CreateRestorePoint();
            //backUp.CreateRestorePoint();
            //Console.WriteLine(backUp.BackUpSize);
            //backUp.SetRestrictionSize(500);
            //backUp.CheckAllRestrictions();
            // backUp.SetRestrictionsType(false);
            //backUp.SetRestrictionLength(1);
            //backUp.SetRestrictionSize(14500);
            //backUp.CreateRestorePoint(false);
            //backUp.CreateRestorePoint(false);
            ////backUp.CheckAllRestrictions();
            //backUp.Print();
            //Console.ReadLine();
            //backUp.CreateRestorePoint(true);
            //backUp.Print();
        }
    }
}
