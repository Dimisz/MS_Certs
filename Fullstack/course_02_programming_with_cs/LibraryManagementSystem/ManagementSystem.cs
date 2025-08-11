namespace LibraryManagementSystem;

public class ManagementSystem(int maxBooksStored)
{
  public List<Book> Books { get; } = new List<Book>(maxBooksStored);

  public readonly List<string> MenuOptions = [
    "Print out all the books",
    "Add a book",
    "Remove a book",
    "Exit",
  ];

  public void PrintMenu()
  {
    Console.WriteLine();
    Console.WriteLine("Available operations:");
    for (int i = 0; i < MenuOptions.Count; i++)
    {

      Console.WriteLine($"{i + 1}. {MenuOptions[i]}");
    }
  }
  public void RemoveBook(string title)
  {
    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
    {
      Console.WriteLine("Book title cannot be empty");
      Console.WriteLine();
      return;
    }

    if (!Contains(title))
    {
      Console.WriteLine($"There's no book with the title '{title}' in the collection.");
      Console.WriteLine();
      return;
    }

    for (int i = 0; i < Books.Count; i++)
    {
      if (string.Equals(Books[i].Title, title))
      {
        Books.RemoveAt(i);
        return;
      }
    }
    Console.WriteLine();
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
    Console.WriteLine($"The book with the title '{title}' has been added successfully");
    Console.WriteLine();
  }

  public void DisplayBooks()
  {
    if (Books.Count == 0)
    {
      Console.WriteLine("There no books in the system yet.");
      return;
    }
    Console.WriteLine("The collection currently contains the following titles:");
    for (int i = 0; i < Books.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {Books[i].Title}.");
    }
    Console.WriteLine();
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
