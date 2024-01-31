using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        //primitive types
        int i;
        string s;
        char c;
        float f;
        double d;
        byte b;
        
        // Lists - new keyword
        List<int> myInts = new List<int>();
        var moreInt = new List<int>();

        moreInt.Add(34);
        moreInt.Add(10);

        //Iterate over items
        foreach(var n in moreInt) {
            System.Console.WriteLine($"n ={n}");
        }
    }
}