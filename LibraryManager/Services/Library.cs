// Services/Library.cs
using LibraryManager.Models;

namespace LibraryManager.Services;

public class Library
{
    private List<Book> books = new();
    private int currentBorrowCount = 0;

    public void AddBook(Book book)
    {
        if (!books.Any(b => b.Title == book.Title && b.Author == book.Author))
        {
            books.Add(book);
            Console.WriteLine("Book added successfully.");
        }
        else
        {
            Console.WriteLine("This book already exists in the library.");
        }
    }

    public void ViewBooks()
    {
        if (!books.Any())
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"[{i}] {books[i]}");
        }
    }

    public void BorrowBook(int index)
    {
        if (index < 0 || index >= books.Count)
        {
            Console.WriteLine("Invalid index.");
            return;
        }

        var book = books[index];

        if (book.IsBorrowed)
        {
            Console.WriteLine("Book is already borrowed.");
            return;
        }

        if (currentBorrowCount >= 3)
        {
            Console.WriteLine("You cannot borrow more than 3 books.");
            return;
        }

        book.Borrow();
        currentBorrowCount++;
        Console.WriteLine("Book borrowed successfully.");
    }

    public void ReturnBook(int index)
    {
        if (index < 0 || index >= books.Count)
        {
            Console.WriteLine("Invalid index.");
            return;
        }

        var book = books[index];

        if (!book.IsBorrowed)
        {
            Console.WriteLine("Book is not borrowed.");
            return;
        }

        if (book.IsOverdue())
        {
            Console.WriteLine("This book is overdue! Please return books on time.");
        }

        book.Return();
        currentBorrowCount--;
        Console.WriteLine("Book returned successfully.");
    }

    public void ListOverdueBooks()
    {
        var overdue = books.Where(b => b.IsOverdue()).ToList();
        if (!overdue.Any())
        {
            Console.WriteLine("No overdue books.");
            return;
        }

        foreach (var book in overdue)
        {
            Console.WriteLine($"{book.Title} by {book.Author} - Borrowed on {book.BorrowedAt?.ToString("yyyy-MM-dd")}");
        }
    }

    public void ExtendBorrow(int index)
    {
        if (index < 0 || index >= books.Count)
        {
            Console.WriteLine("Invalid index.");
            return;
        }

        var book = books[index];

        if (!book.IsBorrowed)
        {
            Console.WriteLine("Book is not borrowed.");
            return;
        }

        if (book.HasExtended)
        {
            Console.WriteLine("Borrow period has already been extended once.");
            return;
        }

        book.ExtendBorrow();
        Console.WriteLine("Borrow period extended by 7 days.");
    }
}
