using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
       bool quit = false;

       string text = "8 And it came to pass that he said unto them: Behold, here are the waters of Mormon (for thus were they called) and now, as ye are desirous to come into the fold of God, and to be called his people, and are willing to bear one another’s burdens, that they may be light; 9 Yea, and are willing to mourn with those that mourn; yea, and comfort those that stand in need of comfort, and to stand as witnesses of God at all times and in all things, and in all places that ye may be in, even until death, that ye may be redeemed of God, and be numbered with those of the first resurrection, that ye may have eternal life— 10 Now I say unto you, if this be the desire of your hearts, what have you against being baptized in the name of the Lord, as a witness before him that ye have entered into a covenant with him, that ye will serve him and keep his commandments, that he may pour out his Spirit more abundantly upon you?";

       Reference reference = new Reference("Mosiah",18,8,10);
       Scripture scripture = new Scripture(text, reference);

       while(quit == false)
       {
            scripture.Display();
            Console.WriteLine("\n\nPress enter to continue or type 'quit' to end.");
            var input = Console.ReadLine();
            scripture.hide();
            if(scripture.isFinished()== true || input == "quit")
            {
               quit = true; 
            }
            
            
       }

        
    }
}