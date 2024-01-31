using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        // while loop
        int count =5;

        while (count < 10)
            System.Console.WriteLine($"Count = {count++}");

        while (count > 10)
        {
            System.Console.WriteLine($"Count = {count}");
            count++;
        }

        // do-while loop
        int anotherCount = 0;
        do{
            System.Console.WriteLine($"AnotherCount = {++anotherCount}");
        } while (anotherCount < 10);

        // for loop
        for(int i=0; i<5; ++i) {
            System.Console.WriteLine($"i = {i}");
        }

        //Assignment Project 3

        // Ask for random number
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);
        //Ask user for random number
        while (randomGenerator !=)
            System.Console.WriteLine("Guess a random number:");
            int guess = int.Parse(Console.ReadLine());
            //Check if higher
            if (guess > randomNumber)
            {

            }

    }
}