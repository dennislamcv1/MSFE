using System;

class LibraryManagementSystem
{
    static string?[] books = new string?[5]; // Library storage (5 books)
    static bool[] isCheckedOut = new bool[5]; // Tracks checked-out status (true = checked out)
    
    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("📚 Library Management System");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Remove a Book");
            Console.WriteLine("3. Check Out a Book"); // ✅ Added check-out feature
            Console.WriteLine("4. Check In a Book"); // ✅ Added check-in feature
            Console.WriteLine("5. Display Available Books");
            Console.WriteLine("6. Search for a Book");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option (1-7): ");

            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    CheckOutBook(); // ✅ New Check-Out Feature
                    break;
                case "4":
                    CheckInBook(); // ✅ New Check-In Feature
                    break;
                case "5":
                    DisplayBooks();
                    break;
                case "6":
                    SearchBook();
                    break;
                case "7":
                    isRunning = false;
                    Console.WriteLine("📖 Exiting the program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("❌ Invalid choice! Please enter a number between 1 and 6.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void AddBook()
    {
        Console.Write("📖 Enter the title of the book to add: ");
        string newBook = Console.ReadLine() ?? string.Empty;

        for (int i = 0; i < books.Length; i++)
        {
            if (string.IsNullOrEmpty(books[i])) // Find an empty slot
            {
                books[i] = newBook;
                isCheckedOut[i] = false; // Mark as available
                Console.WriteLine($"✅ \"{newBook}\" has been added to the library.");
                return;
            }
        }

        Console.WriteLine("❌ The library is full! You cannot add more books.");
    }

    static void RemoveBook()
    {
        Console.Write("📖 Enter the title of the book to remove: ");
        string bookToRemove = Console.ReadLine() ?? string.Empty;

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i]?.Equals(bookToRemove, StringComparison.OrdinalIgnoreCase) == true)
            {
                books[i] = null; // Remove book
                isCheckedOut[i] = false; // Reset status
                Console.WriteLine($"✅ \"{bookToRemove}\" has been removed.");
                return;
            }
        }

        Console.WriteLine("❌ Book not found in the library.");
    }

    static void CheckOutBook()
    {
        Console.Write("📖 Enter the title of the book to check out: ");
        string bookToCheckOut = Console.ReadLine() ?? string.Empty;

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i]?.Equals(bookToCheckOut, StringComparison.OrdinalIgnoreCase) == true)
            {
                if (isCheckedOut[i])
                {
                    Console.WriteLine($"❌ \"{bookToCheckOut}\" is already checked out.");
                }
                else
                {
                    isCheckedOut[i] = true;
                    Console.WriteLine($"✅ \"{bookToCheckOut}\" has been checked out.");
                }
                return;
            }
        }

        Console.WriteLine("❌ Book not found in the library.");
    }

    static void CheckInBook()
    {
        int borrowedCount = 0;
        for (int i = 0; i < isCheckedOut.Length; i++)
        {
            if (isCheckedOut[i])
            {
                borrowedCount++;
            }
        }

        if (borrowedCount >= 3)
        {
            Console.WriteLine("❌ You have reached the borrowing limit (3 books). Please return one before borrowing more.");
            return;
        }

        Console.Write("📖 Enter the title of the book to check in: ");
        string bookToCheckIn = Console.ReadLine() ?? string.Empty;

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i]?.Equals(bookToCheckIn, StringComparison.OrdinalIgnoreCase) == true)
            {
                if (!isCheckedOut[i])
                {
                    Console.WriteLine($"❌ \"{bookToCheckIn}\" is already checked in.");
                }
                else
                {
                    isCheckedOut[i] = false;
                    Console.WriteLine($"✅ \"{bookToCheckIn}\" has been checked in.");
                }
                return;
            }
        }

        Console.WriteLine("❌ Book not found in the library.");
    }

    static void DisplayBooks()
    {
        Console.WriteLine("\n📚 Current Books in Library:");

        bool isEmpty = true;
        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrEmpty(books[i]))
            {
                string status = isCheckedOut[i] ? "🔴 Checked Out" : "🟢 Available";
                Console.WriteLine($"📖 {i + 1}. {books[i]} - {status}");
                isEmpty = false;
            }
        }

        if (isEmpty)
        {
            Console.WriteLine("📭 No books available in the library.");
        }
    }

    static void SearchBook()
{
    Console.Write("🔍 Enter the title of the book to search: ");
    string searchTitle = Console.ReadLine() ?? string.Empty;

    for (int i = 0; i < books.Length; i++)
    {
        if (books[i]?.Equals(searchTitle, StringComparison.OrdinalIgnoreCase) == true)
        {
            string status = isCheckedOut[i] ? "🔴 Checked Out" : "🟢 Available";
            Console.WriteLine($"✅ \"{searchTitle}\" is in the library. Status: {status}");
            return;
        }
    }

    Console.WriteLine($"❌ \"{searchTitle}\" is not found in the library.");
}

}
