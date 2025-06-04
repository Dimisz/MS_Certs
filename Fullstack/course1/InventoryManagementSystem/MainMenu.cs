namespace InventoryManagementSystem;

public static class MainMenu
{
  public static void PrintOptions()
  {
    Console.WriteLine();
    Console.WriteLine("Please, select an operation:");
    Console.WriteLine("Type '1' to view all products");
    Console.WriteLine("Type '2' to add a product");
    Console.WriteLine("Type '3' to delete a product");
    Console.WriteLine("Type '4' to update quantity of a product");
    Console.WriteLine("Type '5' to exit");
  }

  public static int SelectOperation()
  {
    while (true)
    {
      if (int.TryParse(Console.ReadLine(), out int userChoice))
      {
        switch (userChoice)
        {
          case 1:
          case 2:
          case 3:
          case 4:
          case 5:
            return userChoice;
          default:
            Console.WriteLine("Please select a valid number from 1 to 5 inclusive");
            break;
        }
      }
      Console.WriteLine("Please, select a valid number");
    }
  }

}
