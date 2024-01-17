using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string valueFromUser = Console.ReadLine();

        int x = int.Parse(valueFromUser);
        
        if (x >= 90)
        {
            Console.WriteLine("You have an A.");
        }
        else if (x >= 80)
        {
            Console.WriteLine("You have a B.");
        }
        else if (x >= 70)
        {
            Console.WriteLine("You have a C.");
        }
        else if (x >= 60)
        {
            Console.WriteLine("You have a D.");
        }
        else if (x < 60)
        {
            Console.WriteLine("You have an F.");
        }

        if (x >= 70)
        {
            Console.WriteLine("You have a passing grade.");
        }
        else if (x < 70)
        {
            Console.WriteLine("You are currently failing the class.");
        }

    }
}