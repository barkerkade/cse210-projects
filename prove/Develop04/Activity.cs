
public class Activity
{
    protected string countdown;
    
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
            Console.Write("'\'");
            Thread.Sleep(1000);
        }

    }
}