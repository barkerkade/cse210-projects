class Library
{
    private List<LibraryItem> items;
    private List<Patron> patrons;
    private List<Transaction> transactions;
    private string txtFilePath = "library_data.txt";

    public Library()
    {
        items = new List<LibraryItem>();
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
                            Book book = new FictionBook
                            {
                                Title = parts[1],
                                Author = parts[2],
                                Genre = parts[3],
                                IsAvailable = bool.Parse(parts[4]),
                                Theme = parts.Length > 5 ? parts[5] : null
                            };
                            items.Add(book);
                            break;
                        case "Patron":
                            Patron patron = new Patron(parts[1], int.Parse(parts[2]));
                            patrons.Add(patron);
                            break;
                        case "Transaction":
                            Transaction transaction = new Transaction
                            {
                                Item = items.FirstOrDefault(item => item.Title == parts[1]),
                                Patron = patrons.FirstOrDefault(patron => patron.Name == parts[2]),
                                DueDate = DateTime.Parse(parts[3]),
                                IsReturned = bool.Parse(parts[4])
                            };
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
            foreach (LibraryItem item in items)
            {
                string itemData = $"{item.GetType().Name}|{item.Title}|{item.Author}";
                if (item is Book book)
                {
                    itemData += $"|{book.Genre}|{book.IsAvailable}";
                    if (book is FictionBook fictionBook)
                    {
                        itemData += $"|{fictionBook.Theme}";
                    }
                }
                writer.WriteLine(itemData);
            }
            foreach (Patron patron in patrons)
            {
                writer.WriteLine($"Patron|{patron.Name}|{patron.ID}");
            }
            foreach (Transaction transaction in transactions)
            {
                writer.WriteLine($"Transaction|{transaction.Item.Title}|{transaction.Patron.Name}|{transaction.DueDate}|{transaction.IsReturned}");
            }
        }
    }

    public void AddItem(LibraryItem item)
    {
        items.Add(item);
        SaveDataToTxt();
    }

    public void AddPatron(Patron patron)
    {
        patrons.Add(patron);
        SaveDataToTxt();
    }

    public void BorrowItem(LibraryItem item, Patron patron)
    {
        if (item is Book book && book.IsAvailable)
        {
            book.IsAvailable = false;
            transactions.Add(new Transaction { Item = item, Patron = patron, DueDate = DateTime.Now.AddDays(14) });
            SaveDataToTxt();
            Console.WriteLine($"{patron.Name} has borrowed {item.Title}.");
        }
        else
        {
            Console.WriteLine("Sorry, the item is not available for borrowing.");
        }
    }

    public void ReturnItem(LibraryItem item, Patron patron)
    {
        if (item is Book book)
        {
            book.IsAvailable = true;
        }
        transactions.RemoveAll(transaction => transaction.Item == item && transaction.Patron == patron && !transaction.IsReturned);
        SaveDataToTxt();
        Console.WriteLine($"{patron.Name} has returned {item.Title}.");
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
        Console.Write("Is Available (true/false): ");
        bool isAvailable = bool.Parse(Console.ReadLine());

        Book book = new FictionBook { Title = title, Author = author, Genre = genre, IsAvailable = isAvailable };
        AddItem(book);
        Console.WriteLine("Book added successfully.");
    }

    public void AddPatronFromInput()
    {
        Console.WriteLine("\nEnter patron details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Patron patron = new Patron(name, patrons.Count + 1);
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
            LibraryItem item = items.FirstOrDefault(item => item.Title == bookTitle && item is Book);
            if (item != null)
            {
                BorrowItem(item, patron);
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
            LibraryItem item = transactions.FirstOrDefault(transaction => transaction.Patron == patron && transaction.Item.Title == bookTitle)?.Item;
            if (item != null)
            {
                ReturnItem(item, patron);
            }
            else
            {
                Console.WriteLine($"Book '{bookTitle}' not found in the patron's borrowed items.");
            }
        }
        else
        {
            Console.WriteLine($"Patron '{patronName}' not found.");
        }
    }
}