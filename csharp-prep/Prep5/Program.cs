using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

class Program
{
     static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");

        //Functions
        
        int Add2(int number) {
            return number + 2;
        }
        int more = Add2(10);

         // variable scope

         var y = 0;
        {
            var w = 10;
            w = y + 4;
            y = w + 5;
        }
    }
}