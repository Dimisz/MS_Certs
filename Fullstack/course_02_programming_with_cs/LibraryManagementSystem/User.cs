using System;

namespace LibraryManagementSystem;

public class User(int borrowingLimit)
{
  public List<Book> BooksBorrowed { get; set; } = [];
  public int BorrowingLimit { get; set; } = borrowingLimit;


  public void CheckOut(Book? book, string title)
  {
    if (book is null)
    {
      Console.WriteLine($"The book '{title}' is not in the system. Make sure you are trying to borrow the correct title!");
      Console.WriteLine();
      return;
    }
    if (book.IsCheckedOut)
    {
      Console.WriteLine($"The book '{title}' has already been checked out. Try other title!");
      Console.WriteLine();
      return;
    }
    if (BorrowingLimit <= BooksBorrowed.Count)
    {
      Console.WriteLine($"You've already reached your borroing limit (currently {BorrowingLimit} books). Return some books before borrowing new ones");
      Console.WriteLine();
      return;
    }
    book.IsCheckedOut = true;
    BooksBorrowed.Add(book);
    Console.WriteLine("You've successfully borrowed the book. Enjoy your read!");
    Console.WriteLine();
  }

  public void CheckIn(Book? book, string title)
  {
    if (book is null)
    {
      Console.WriteLine($"The book '{title}' is not in the system. Make sure you are trying to return a correct title!");
      Console.WriteLine();
      return;
    }
    if (!book.IsCheckedOut)
    {
      Console.WriteLine($"The book '{title}' is registered in the system but it has not been checked out. Make sure you are trying to return a correct title!");
      Console.WriteLine();
      return;
    }

    for (int i = 0; i < BooksBorrowed.Count; i++)
    {
      if (string.Equals(BooksBorrowed[i].Title, title))
      {
        BooksBorrowed.RemoveAt(i);
        book.IsCheckedOut = false;
        Console.WriteLine("You've successfully returned the book. Enjoy your read!");
        Console.WriteLine();
        return;
      }
    }

  }
}
