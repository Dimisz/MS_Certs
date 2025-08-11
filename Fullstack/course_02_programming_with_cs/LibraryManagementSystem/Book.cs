using System;

namespace LibraryManagementSystem;

public class Book(string title)
{
  public string Title { get; set; } = title;
  public bool IsCheckedOut { get; set; } = false;
}
