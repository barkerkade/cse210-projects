using System.IO;

class Program
{
    public Journal journal;
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exit = false;

        Entry entry = new Entry();

        while (!exit)
        {
            Console.Clear();
            int choice = ShowMenu();


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

        static string GetPrompt()
        {
            return "";

        }

     void Run()
        {

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