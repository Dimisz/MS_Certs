namespace LibraryManagementSystem;

public class ManagementSystem(int maxBooksStored)
{
  public List<Book> Books { get; } = new List<Book>(maxBooksStored);

  public void RemoveBook(string title)
  {
    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
    {
      Console.WriteLine("Book title cannot be empty");
      return;
    }

    if (!Contains(title))
    {
      Console.Write($"There's no book with the title '{title}' in the collection.");
      return;
    }
  }

  public void AddBook(string title)
  {
    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
    {
      Console.WriteLine("Book title cannot be empty");
      return;
    }

    if (Books.Count >= maxBooksStored)
    {
      Console.WriteLine($"The system already contains {Books.Count} books in it. No more books can be added.");
      return;
    }

    if (Contains(title))
    {
      Console.WriteLine($"The system already contains the books with the title '{title}'");
      return;
    }

    Books.Add(new Book(title));
    Console.Write($"The book with the title {title} has been added successfully");
  }

  private bool Contains(string title)
  {
    // currently assuming title would be unique
    foreach (Book book in Books)
    {
      if (book.Title == title) return true;
    }
    return false;
  }
}
