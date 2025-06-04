// See https://aka.ms/new-console-template for more information
using InventoryManagementSystem;
using InventoryManagementSystem.Models;

List<Product> prods = new();
prods.Add(new Product
{
  Name = "Jeans",
  Price = 5,
  Quantity = 10
});
string userChoice = UserInputHandler.GetProductName(prods);
Console.WriteLine(userChoice);
