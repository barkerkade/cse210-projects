using System;

class Program
{
 static void Main(string[] args)
    {
        
        bool exit = false;
        Breathing breathingActivity = new Breathing();

        Listing listingActivity = new Listing();

        Reflecting reflectingActivity = new Reflecting();

        

        while (!exit)
        {
           //Console.Clear();
            int choice = ShowMenu();
            if(choice == 1)
            {
                breathingActivity.Start();
            }
            else if(choice == 2)
            {
                reflectingActivity.StartReflecting();
            }
            else if (choice == 3)
            {
                listingActivity.StartListing();
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