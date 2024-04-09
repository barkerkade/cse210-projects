class NonFictionBook : Book
{
    public string Subject { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Subject: {Subject}");
    }
}