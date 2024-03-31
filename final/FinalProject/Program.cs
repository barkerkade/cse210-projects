using System;
using System.Collections.Generic;

// Base class for Person
class Person
{
    public string Name { get; set; }
    public int ID { get; set; }
}

// Book class representing a book entity
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
}

// Derived classes FictionBook and NonFictionBook
class FictionBook : Book
{
    public string Theme { get; set; }
}

class NonFictionBook : Book
{
    public string Subject { get; set; }
}

// Patron class representing a library patron
class Patron : Person
{
    public List<Book> BorrowedBooks { get; set; }

    public Patron()
    {
        BorrowedBooks = new List<Book>();
    }
}

// Transaction class representing a library transaction
class Transaction
{
    public Book Book { get; set; }
    public Patron Patron { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsReturned { get; set; }
}

// Library class representing the library entity
class Library
{
    private List<Book> books;
    private List<Patron> patrons;
    private List<Transaction> transactions;

    public Library()
    {
        books = new List<Book>();
        patrons = new List<Patron>();
        transactions = new List<Transaction>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void AddPatron(Patron patron)
    {
        patrons.Add(patron);
    }

    public void BorrowBook(Book book, Patron patron)
    {
        if (book.IsAvailable)
        {
            book.IsAvailable = false;
            patron.BorrowedBooks.Add(book);
            transactions.Add(new Transaction { Book = book, Patron = patron, DueDate = DateTime.Now.AddDays(14) });
            Console.WriteLine($"{patron.Name} has borrowed {book.Title}.");
        }
        else
        {
            Console.WriteLine("Sorry, the book is not available for borrowing.");
        }
    }

    public void ReturnBook(Book book, Patron patron)
    {
        book.IsAvailable = true;
        patron.BorrowedBooks.Remove(book);
        foreach (var transaction in transactions)
        {
            if (transaction.Book == book && transaction.Patron == patron && !transaction.IsReturned)
            {
                transaction.IsReturned = true;
                Console.WriteLine($"{patron.Name} has returned {book.Title}.");
                return;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Sample usage
        Library library = new Library();

        Book book1 = new FictionBook { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic", Theme = "American Dream" };
        Book book2 = new NonFictionBook { Title = "Sapiens", Author = "Yuval Noah Harari", Genre = "History", Subject = "Anthropology" };

        library.AddBook(book1);
        library.AddBook(book2);

        Patron patron1 = new Patron { Name = "John", ID = 1 };
        Patron patron2 = new Patron { Name = "Alice", ID = 2 };

        library.AddPatron(patron1);
        library.AddPatron(patron2);

        library.BorrowBook(book1, patron1);
        library.BorrowBook(book2, patron2);

        library.ReturnBook(book1, patron1);
    }
}
