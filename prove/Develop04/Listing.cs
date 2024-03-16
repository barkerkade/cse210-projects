class Listing : Activity
{
    private List<string> prompts = new List<string>
    {
        "Talk about your favorite meal of today",
        "Tell me about your job today",
        "How are you?",
        "Did you do anything new today?",
        "How have you seen the Lord in your life today?"
    };
    public Listing() : base("This activity is for listing ideas based on a prompt.", "Listing Activity")
    {
        
    }
    public void StartListing()
    {
        Begin();
        
        int index = new Random().Next(0, prompts.Count);
        prompt = prompts[index];

        
        Console.WriteLine("Get Ready...");
        DisplaySpinner (5);
        Console.WriteLine(" List as many responses as possible following the prompt:");
        Console.WriteLine(prompts[index]);
        Console.WriteLine("You may begin in:");
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(3);
        

        while(DateTime.Now < futureTime)
        {
            Console.Write("3");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("2");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("1");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            

        }
        int responses = 0;
        while (!AmIDone())
        {
            Console.Write(">");
            Console.ReadLine();
            responses += 1;
        }

        Console.WriteLine($"You completed {responses} items.");
        
        End();


    }
}