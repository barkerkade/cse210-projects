public class Journal
{
    private List<Entry> entries = new List<Entry>();

    

    public Journal()
    {
        
    }

    public Journal(string import)
    {
        string[] lines = System.IO.File.ReadAllLines(import);
        foreach (var item in lines)
        {
            string[] parts = item.Split("^^");
            string response = parts[0];
            string prompt = parts[1];
            string date = parts[2];

            Entry NewEntry = new Entry(response, prompt, date);
            entries.Add(NewEntry);
        }
    }

    public void AddEntry()
    {
        Entry entry = new Entry();
        entries.Add(entry);
    }

    public void Display()
    {
        Console.Clear();
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
        Console.WriteLine("\nPress to continue.");
        Console.ReadLine();
    }

    public void SaveFile(string filename)
    {
        List<string> entriesToSave = new List<string>();

         foreach (Entry entry in entries)
        {
            entriesToSave.Add(entry.Export());
        }

        System.IO.File.WriteAllLines(filename, entriesToSave ); 
    }
}