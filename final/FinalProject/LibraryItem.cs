abstract class LibraryItem
{
    public string Title { get; set; }
    public string Author { get; set; }

    // Abstract method for displaying item details
    public abstract void DisplayDetails();
}