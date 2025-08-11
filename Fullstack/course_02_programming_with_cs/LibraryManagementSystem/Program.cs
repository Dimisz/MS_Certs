// See https://aka.ms/new-console-template for more information
using LibraryManagementSystem;

int maxBooksStored = 5;
int borrowingLimit = 3;

bool keepRunning = true;

ManagementSystem managementSystem = new(maxBooksStored);
User user = new(borrowingLimit);
while (keepRunning)
{
  managementSystem.PrintMenu();
  int optionChosen = UserInput.GetIntegerInput("Please, select an option:", managementSystem.MenuOptions.Count);
  switch (optionChosen)
  {
    case 0:
      managementSystem.DisplayBooks();
      break;
    case 1:
      string titleToSearch = UserInput.GetStringInput("Please, enter the title of a book you want to search for:");
      if (managementSystem.SearchByTitle(titleToSearch) is null)
      {
        Console.WriteLine($"The book '{titleToSearch}' is not available.");
      }
      else
      {
        Console.WriteLine($"The book '{titleToSearch}' is available.");
      }
      Console.WriteLine();
      break;
    case 2:
      string titleToAdd = UserInput.GetStringInput("Please, enter the title of a book you want to add:");
      managementSystem.AddBook(titleToAdd);
      break;
    case 3:
      string titleToRemove = UserInput.GetStringInput("Please, enter the title of a book you want to remove from the system:");
      managementSystem.RemoveBook(titleToRemove);
      break;
    case 4:
      // checkout
      string titleToBorrow = UserInput.GetStringInput("Please, enter the title of a book you want to borrow:");
      user.CheckOut(managementSystem.SearchByTitle(titleToBorrow), titleToBorrow);
      break;
    case 5:
      // check in
      Console.WriteLine("Hi");
      break;

    case 6:
      keepRunning = false;
      break;
    default:
      Console.WriteLine("Unable to process a request");
      break;
  }
}

Console.WriteLine("Termnating...");
