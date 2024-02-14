public class Entry
{
    public string response;

    public string prompt;

    public string date;

    public Entry(string response, string prompt, string date)
    {
        this.response = response;
        this.prompt = prompt;
        this.date = date;
    }
    public Entry()
    {
        int index = new Random().Next(0, prompts.Count);
        Console.WriteLine(prompts[index]);
        prompt = prompts[index];
        response = Console.ReadLine();
        date = DateTime.Now.ToString();

    }
   
    List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string Export()
    {
        return $"{response}^^{prompt}^^{date}";
    }

    

    public void Display()
    {
        Console.WriteLine(response);
    }
}