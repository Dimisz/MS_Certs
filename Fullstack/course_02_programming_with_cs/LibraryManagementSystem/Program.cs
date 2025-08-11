// See https://aka.ms/new-console-template for more information
using LibraryManagementSystem;

int maxBooksStored = 5;
bool keepRunning = true;
ManagementSystem managementSystem = new(maxBooksStored);
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
      string titleToAdd = UserInput.GetStringInput("Please, enter the title of a book you want to add:");
      managementSystem.AddBook(titleToAdd);
      break;
    case 2:
      string titleToRemove = UserInput.GetStringInput("Please, enter the title of a book you want to remove from the system:");
      managementSystem.RemoveBook(titleToRemove);
      break;
    case 3:
      keepRunning = false;
      break;
    default:
      Console.WriteLine("Unable to process a request");
      break;
  }
}

Console.WriteLine("Termnating...");
