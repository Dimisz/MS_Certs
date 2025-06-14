using System;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem;

public static class UserInput
{
  // ASK USER TO GET A PRODUCT PRICE
  // keeps asking for input until user enters a valid positive number (double)
  public static double GetProductPrice()
  {
    Console.WriteLine("Please, enter the price");
    while (true)
    {
      if (double.TryParse(Console.ReadLine(), out double price) && price > 0)
        return price;
      Console.WriteLine("Enter a valid positive number.");
    }
  }

  // ASK USER TO ENTER PRODUCT QTY
  // keeps asking for input until user enters a valid positive number (int)
  public static int GetProductQty()
  {
    Console.WriteLine("Please, enter the product quantity");
    while (true)
    {
      if (int.TryParse(Console.ReadLine(), out int qty) && qty > 0)
        return qty;
      Console.WriteLine("Enter a valid positive whole number.");
    }
  }

  // ASK USER TO ENTER PRODUCT NAME
  // keeps asking for a valid and unique (i.e. not on the list) product name
  // user can type 'q' or 'Q' to return to the main menu
  public static string GetProductName(List<Product> products)
  {
    while (true)
    {
      Console.WriteLine("Enter name of the product you want to add or type 'q' to return to the main menu:");
      string? initialInput = Console.ReadLine();
      if (string.IsNullOrEmpty(initialInput))
      {
        Console.WriteLine("Input cannot be empty");
        continue;
      }
      else if (string.Equals(initialInput.ToLower().Trim(), "q"))
      {
        return "q";
      }
      else
      {
        bool alreadyInDB = IsProductAlreadyInDB(initialInput, products);
        if (alreadyInDB)
          continue;
        else
          return initialInput.Trim();
      }
    }
  }

  // checks if a product with the same name is already in the list
  private static bool IsProductAlreadyInDB(string productName, List<Product> products)
  {
    productName = productName.ToLower().Trim();
    foreach (Product product in products)
    {
      if (string.Equals(productName, product.Name.ToLower()))
      {
        Console.WriteLine($"Product {productName} already exists:");
        Console.WriteLine(product.AsString());
        return true;
      }
    }
    return false;
  }

  // ASKS USER TO ENTER INDEX OF A PRODUCT (TO DELETE OR TO EDIT QTY)
  // Checks the input to be a valid int
  // Checks for IndeOutOfBoundsException:
  // - productsCount - current length of products list
  public static int GetIndexOfProduct(int productsCount)
  {
    string? userInput;

    while (true)
    {
      Console.WriteLine();
      Console.WriteLine("Select a valid index or type 'q' to return to the main menu");
      userInput = Console.ReadLine();
      // user selected 'q' -> wants to quit the operation 
      // and return to the main menu
      if (!string.IsNullOrEmpty(userInput)
          && string.Equals(userInput.ToLower().Trim(), "q"))
      {
        return -1;
      }
      if (int.TryParse(userInput, out int ind))
      {
        // we assume that user will enter indices starting with 1
        // so we offset by 1
        if (ind > 0 && ind <= productsCount)
        {
          // however, we return ready-to-use index without the offset
          return ind - 1;
        }
        else
        {
          Console.WriteLine("Invalid index: value is too low or too high.");
        }
      }
      else
      {
        Console.WriteLine("Please, enter a valid whole number");
      }
    }
  }
}
