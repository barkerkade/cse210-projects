class Reflecting : Activity
{
        private List<string> prompts = new List<string>
    {
        "Think of a time when you felt scared.",
        "Think of a time when you had to do something outside your comfort zone.",
        "Think of a time you  failed at an objective.",
        "Think of when you felt stuck.",
        "Think of a time that you had to figure something out without any help."
    };
                private List<string> questions = new List<string>
    {
        "What did you do?",
        "How did you better yourself?",
        "How long did it take for the situation to get better?",
        "Would you do it better if it happened in the future?",
        "How would you get help from God?"
    };
    public Reflecting() : base("This activity is for reflecting on a prompt", "Reflecting Activity")
    {
        
    }

    public void StartReflecting()
    {
        Begin();
        
        

        
        
        Console.WriteLine(" List as many responses as possible following the prompt:");
        
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

        int index = new Random().Next(0, prompts.Count);
        prompt = prompts[index]; 
        Console.WriteLine(prompts[index]);

        while (!AmIDone())
        {
            
            index = new Random().Next(0, questions.Count);
            question = questions[index]; 
            Console.WriteLine(questions[index]);
            Console.ReadLine();
            DisplaySpinner(5);

        }

        Console.WriteLine($"You completed {responses} items.");
        
        End();


    }
}