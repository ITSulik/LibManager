using LibraryManager.Models;
using LibraryManager.Services;

var library = new Library();
bool running = true;

while (running)
{
    Console.WriteLine(@"
Library Manager
---------------
1. Add a new book
2. View all books
3. Borrow a book
4. Return a book
5. View overdue books
6. Extend borrow period
7. Exit
");

    Console.Write("Choose an option: ");
    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("Enter title: ");
string? titleInput = Console.ReadLine();

Console.Write("Enter author: ");
string? authorInput = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(titleInput) && !string.IsNullOrWhiteSpace(authorInput))
{
    library.AddBook(new Book(titleInput, authorInput));
}
else
{
    Console.WriteLine("Invalid input. Title and author cannot be empty.");
}

            break;

        case "2":
            library.ViewBooks();
            break;

        case "3":
            Console.Write("Enter index of the book to borrow: ");
            if (int.TryParse(Console.ReadLine(), out int borrowIndex))
                library.BorrowBook(borrowIndex);
            break;

        case "4":
            Console.Write("Enter index of the book to return: ");
            if (int.TryParse(Console.ReadLine(), out int returnIndex))
                library.ReturnBook(returnIndex);
            break;

        case "5":
            library.ListOverdueBooks();
            break;

        case "6":
            Console.Write("Enter index of the book to extend: ");
            if (int.TryParse(Console.ReadLine(), out int extendIndex))
                library.ExtendBorrow(extendIndex);
            break;

        case "7":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }

    Console.WriteLine();
}
