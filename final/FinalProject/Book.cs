class Book : LibraryItem
{
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
    }
}