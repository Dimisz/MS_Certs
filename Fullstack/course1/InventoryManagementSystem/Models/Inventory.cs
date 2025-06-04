using System;

namespace InventoryManagementSystem.Models;

public class Inventory
{
  public List<Product> Products { get; }

  public Inventory()
  {
    Products = [];
  }

  public void PrintAll()
  {
    if (Products.Count == 0)
    {
      Console.WriteLine("There're no products yet.");
      return;
    }
    for (int i = 0; i < Products.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {Products[i].AsString()}");
    }
  }

  public void EditProductQty()
  {
    if (Products.Count == 0)
    {
      Console.WriteLine("There's no inventory yet. Nothing to edit.");
      return;
    }

    PrintAll();
    int indexToEdit = UserInput.GetIndexOfProduct(Products.Count);
    if (indexToEdit == -1)
    {
      Console.WriteLine("No changes saved. Returning to the main menu...");
      return;
    }

    while (true)
    {
      Console.WriteLine($"Product name: {Products[indexToEdit].Name}, current quantity: {Products[indexToEdit].Quantity}");
      Console.WriteLine("Enter the new quantity for the product or type 'q' to cancel the operation:");

      string? userInput = Console.ReadLine();
      if (!string.IsNullOrEmpty(userInput) && string.Equals(userInput.ToLower().Trim(), "q"))
      {
        Console.WriteLine("No changes saved. Returning to the main menu...");
        return;
      }
      if (int.TryParse(userInput, out int newQty))
      {
        if (newQty < 0)
        {
          Console.WriteLine("Quantity cannot be lower than 0");
          continue;
        }
        else
        {
          Products[indexToEdit].Quantity = newQty;
          Console.WriteLine("Quantity of the product has been changed successfully.");
          Console.WriteLine("Returning to the main menu...");
          return;
        }
      }
    }
  }

  public void DeleteProduct()
  {
    if (Products.Count == 0)
    {
      Console.WriteLine("There's no inventory yet. Nothing to delete.");
      return;
    }

    PrintAll();
    int indexToDelete = UserInput.GetIndexOfProduct(Products.Count);
    if (indexToDelete == -1)
    {
      Console.WriteLine("No changes saved. Returning to the main menu...");
      return;
    }
    Products.RemoveAt(indexToDelete);
    Console.WriteLine("Product has been deleted successfully.");
    Console.WriteLine("Returning to the main menu");
  }

  public void AddProduct()
  {
    string productName = UserInput.GetProductName(Products);
    if (string.Equals(productName.ToLower().Trim(), "q"))
    {
      Console.WriteLine("Adding a new product cancelled.");
      Console.WriteLine("Returning to the main menu...");
      return;
    }
    double productPrice = UserInput.GetProductPrice();
    int productQty = UserInput.GetProductQty();
    Products.Add(
      new Product
      {
        Name = productName,
        Price = productPrice,
        Quantity = productQty
      });
    Console.WriteLine("Product added successfully");
    Console.WriteLine("Returning to the main menu...");
  }
}
