class Transaction
{
    public LibraryItem Item { get; set; }
    public Patron Patron { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsReturned { get; set; }
}