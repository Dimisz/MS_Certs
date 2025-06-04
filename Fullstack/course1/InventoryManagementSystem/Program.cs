// See https://aka.ms/new-console-template for more information
using InventoryManagementSystem;
using InventoryManagementSystem.Models;

Console.WriteLine("Welcome to the inventory management system!");
Inventory inventory = new();
int selectedOption = 0;
do
{
  MainMenu.PrintOptions();
  selectedOption = MainMenu.SelectOperation();
  switch (selectedOption)
  {
    case 1:
      inventory.PrintAll();
      break;
    case 2:
      inventory.AddProduct();
      break;
    case 3:
      inventory.DeleteProduct();
      break;
    case 4:
      inventory.EditProductQty();
      break;
    case 5:
      Console.WriteLine("Exiting...");
      break;
    default:
      Console.WriteLine("Invalid option...");
      break;
  }
} while (selectedOption != 5);

