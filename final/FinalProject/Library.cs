class Library
{
    private List<Book> books;
    private List<Patron> patrons;
    private List<Transaction> transactions;
    private string txtFilePath = "library_data.txt";

    public Library()
    {
        books = new List<Book>();
        patrons = new List<Patron>();
        transactions = new List<Transaction>();
        LoadDataFromTxt();
    }

    public void LoadDataFromTxt()
    {
        if (File.Exists(txtFilePath))
        {
            string[] lines = File.ReadAllLines(txtFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 3)
                {
                    string type = parts[0];
                    switch (type)
                    {
                        case "Book":
                            Book book = new Book { Title = parts[1], Author = parts[2], Genre = parts[3], IsAvailable = bool.Parse(parts[4]) };
                            books.Add(book);
                            break;
                        case "Patron":
                            Patron patron = new Patron { Name = parts[1], ID = int.Parse(parts[2]) };
                            patrons.Add(patron);
                            break;
                        case "Transaction":
                            Transaction transaction = new Transaction { BookTitle = parts[1], PatronName = parts[2], DueDate = DateTime.Parse(parts[3]), IsReturned = bool.Parse(parts[4]) };
                            transactions.Add(transaction);
                            break;
                    }
                }
            }
        }
    }

    public void SaveDataToTxt()
    {
        using (StreamWriter writer = new StreamWriter(txtFilePath))
        {
            foreach (Book book in books)
            {
                writer.WriteLine($"Book|{book.Title}|{book.Author}|{book.Genre}|{book.IsAvailable}");
            }
            foreach (Patron patron in patrons)
            {
                writer.WriteLine($"Patron|{patron.Name}|{patron.ID}");
            }
            foreach (Transaction transaction in transactions)
            {
                writer.WriteLine($"Transaction|{transaction.BookTitle}|{transaction.PatronName}|{transaction.DueDate}|{transaction.IsReturned}");
            }
        }
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        SaveDataToTxt();
    }

    public void AddPatron(Patron patron)
    {
        patrons.Add(patron);
        SaveDataToTxt();
    }

    public void BorrowBook(Book book, Patron patron)
    {
        if (book.IsAvailable)
        {
            book.IsAvailable = false;
            patron.BorrowedBooks.Add(book);
            transactions.Add(new Transaction { BookTitle = book.Title, PatronName = patron.Name, DueDate = DateTime.Now.AddDays(14) });
            SaveDataToTxt();
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
            if (transaction.BookTitle == book.Title && transaction.PatronName == patron.Name && !transaction.IsReturned)
            {
                transaction.IsReturned = true;
                SaveDataToTxt();
                Console.WriteLine($"{patron.Name} has returned {book.Title}.");
                return;
            }
        }
    }

    public void DisplayMenu()
    {
        Console.WriteLine("\nLibrary Management System Menu:");
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. Add Patron");
        Console.WriteLine("3. Borrow Book");
        Console.WriteLine("4. Return Book");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            DisplayMenu();
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddBookFromInput();
                        break;
                    case 2:
                        AddPatronFromInput();
                        break;
                    case 3:
                        BorrowBookFromInput();
                        break;
                    case 4:
                        ReturnBookFromInput();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
            }
        }
    }

    public void AddBookFromInput()
    {
        Console.WriteLine("\nEnter book details:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();
        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        Book book = new Book { Title = title, Author = author, Genre = genre };
        AddBook(book);
        Console.WriteLine("Book added successfully.");
    }

    public void AddPatronFromInput()
    {
        Console.WriteLine("\nEnter patron details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Patron patron = new Patron { Name = name, ID = patrons.Count + 1 };
        AddPatron(patron);
        Console.WriteLine("Patron added successfully.");
    }

    public void BorrowBookFromInput()
    {
        Console.WriteLine("\nEnter the name of the patron borrowing the book:");
        string patronName = Console.ReadLine();
        Patron patron = patrons.FirstOrDefault(p => p.Name == patronName);
        if (patron != null)
        {
            Console.WriteLine("\nEnter the title of the book to borrow:");
            string bookTitle = Console.ReadLine();
            Book book = books.FirstOrDefault(b => b.Title == bookTitle);
            if (book != null)
            {
                BorrowBook(book, patron);
            }
            else
            {
                Console.WriteLine($"Book '{bookTitle}' not found.");
            }
        }
        else
        {
            Console.WriteLine($"Patron '{patronName}' not found.");
        }
    }

    public void ReturnBookFromInput()
    {
        Console.WriteLine("\nEnter the name of the patron returning the book:");
        string patronName = Console.ReadLine();
        Patron patron = patrons.FirstOrDefault(p => p.Name == patronName);
        if (patron != null)
        {
            Console.WriteLine("\nEnter the title of the book to return:");
            string bookTitle = Console.ReadLine();
            Book book = patron.BorrowedBooks.FirstOrDefault(b => b.Title == bookTitle);
            if (book != null)
            {
                ReturnBook(book, patron);
            }
            else
            {
                Console.WriteLine($"Book '{bookTitle}' not found.");
            }
        }
        else
        {
            Console.WriteLine($"Patron '{patronName}' not found.");
        }
    }
}
