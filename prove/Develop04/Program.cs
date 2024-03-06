using System;

class Program
{
 static void Main(string[] args)
    {
        
        bool exit = false;

        

        while (!exit)
        {
            Console.Clear();
            int choice = ShowMenu();
            if(choice == 1)
            {
                
            }
            else if(choice == 2)
            {
                
            }
            else if (choice == 3)
            {
               
            }
            
            else if(choice == 4)
            {
                exit = true;
            }


        }

    }
    
   
        static int ShowMenu()
        {
            Console.WriteLine("Calming Activity");
            Console.WriteLine(" Choose one of the following:");
            Console.WriteLine(" 1. Breathing");
            Console.WriteLine(" 2. Reflecting");
            Console.WriteLine(" 3. Listing");
            Console.WriteLine(" 4. Quit");

         Console.Write("\nEnter your choice: ");
            var choice = int.Parse(Console.ReadLine());
         return choice;
        
        }
    
}