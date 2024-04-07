class Patron : Person
{
    public List<Book> BorrowedBooks { get; set; }

    public Patron()
    {
        BorrowedBooks = new List<Book>();
    }
}
