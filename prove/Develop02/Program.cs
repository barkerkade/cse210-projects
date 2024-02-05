using System;

class Program
{
    public Journal journal;
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");
    }
    static int ShowMenu()
    {
        Console.WriteLine("Journal Menu.")
    }
        string GetPrompt()
    {


    }

    void Run()
    {

    }

    void SaveToFile()
    {
        Console.Write("Enter filename:");
        var filename = Console.ReadLine();
        System.IO.File.WriteAllLines(filename);

    }

    void LoadFromFile()
    {

    }
}