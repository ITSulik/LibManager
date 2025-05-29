// Models/Book.cs
namespace LibraryManager.Models;

public class Book
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public bool IsBorrowed { get; private set; }
    public DateTime? BorrowedAt { get; private set; }
    public bool HasExtended { get; private set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
        IsBorrowed = false;
    }

    public void Borrow()
    {
        IsBorrowed = true;
        BorrowedAt = DateTime.Now;
        HasExtended = false;
    }

    public void Return()
    {
        IsBorrowed = false;
        BorrowedAt = null;
        HasExtended = false;
    }

    public void ExtendBorrow()
    {
        if (IsBorrowed && !HasExtended)
        {
            BorrowedAt = BorrowedAt?.AddDays(7);
            HasExtended = true;
        }
    }

    public bool IsOverdue()
    {
        return IsBorrowed && BorrowedAt.HasValue && (DateTime.Now - BorrowedAt.Value).TotalDays > 14;
    }

    public override string ToString()
    {
        if (IsBorrowed)
            return $"{Title} by {Author} - Borrowed on {BorrowedAt?.ToString("yyyy-MM-dd")}";
        return $"{Title} by {Author} - Available";
    }
}
