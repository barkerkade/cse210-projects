class FictionBook : Book
{
    public string Theme { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Theme: {Theme}");
    }
}