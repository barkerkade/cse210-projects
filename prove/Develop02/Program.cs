using System.IO;

class Program
{
    
    static void Main(string[] args)
    {
        string filename = "Journal.txt";
        Journal journal = new Journal(filename);
        bool exit = false;

        Entry entry = new Entry();

        while (!exit)
        {
            Console.Clear();
            int choice = ShowMenu();
            if(choice == 1)
            {
                
            }
            else if(choice == 2)
            {
                journal.Display();
            }
            else if (choice == 3)
            {
                //Ask user for filename
                //Load new journal
            }
            else if(choice == 4)
            {
                journal.SaveFile(filename);
            }
            else if(choice == 5)
            {
                exit = true;
            }


        }

    }
    
        static int ShowMenu()
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine(" Choose one of the following:");
            Console.WriteLine(" 1. Write");
            Console.WriteLine(" 2. Display");
            Console.WriteLine(" 3. Load");
            Console.WriteLine(" 4. Save");
            Console.WriteLine(" 5. Quit");

         Console.Write("\nEnter your choice: ");
            var choice = int.Parse(Console.ReadLine());
         return choice;
        
        }



        void SaveToFile(string[] lines)
        {
         Console.Write("Enter filename:");
            var filename = Console.ReadLine();
         System.IO.File.WriteAllLines(filename, lines);

     }

        static string[] LoadFromFile()
        {
            Console.Write("Enter filename: ");
            var filename = Console.ReadLine();
            return System.IO.File.ReadAllLines(filename);
        }
    
}