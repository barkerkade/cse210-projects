public class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(string book, int chapter, int startVerse, int endVerse = 0)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

//Mosiah 18:8-10
    public void Display()
    {
        if (endVerse == 0){
        Console.WriteLine($"{book} {chapter}:{startVerse}");
        }
        else {
          Console.WriteLine($"{book} {chapter}:{startVerse}-{endVerse}"); 
        }
    }


}