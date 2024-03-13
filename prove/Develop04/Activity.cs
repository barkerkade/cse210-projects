
using System.Security.Cryptography.X509Certificates;

public class Activity
{
    protected string countdown;

    protected int activityDuration;

    protected string description;

    protected string activityTitle;
    
    public Activity (string description, string activityTitle)
    {
       this.description = description; 
       this.activityTitle = activityTitle;
    }
    public void GetDuration()
    {
        Console.WriteLine($"How long do you want to do {activityTitle}?");
        activityDuration = int.Parse(Console.ReadLine());
        
    }

    public void DisplayIntro()
    {
        Console.WriteLine($"Welcome to the {activityTitle} \n\n {description}");
    }
    public void Begin()
    {
        DisplayIntro();
        GetDuration();
    }
    public void End()
    {
        Console.WriteLine($"Congrats on completing {activityTitle}! ");
        Thread.Sleep(3000);
    }
    protected void DisplaySpinner(int duration)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);
        

        while(DateTime.Now < futureTime)
        {
            Console.WriteLine(" Get ready:");
            Console.Write("|");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(1000);
        }

    }
}