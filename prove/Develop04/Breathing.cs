class Breathing : Activity
{
    public Breathing() : base("This activity is for controlled breathing", "Breathing Activity")
    {
        
    }
    public void Start()
    {
        Begin();
        Console.WriteLine("Get Ready");
        while (!AmIDone())
        {
            Console.WriteLine("Breath in");
            DisplaySpinner(5);
            Console.WriteLine("Breath out");
            DisplaySpinner(5);
        }

        End();
    }
    
    
}