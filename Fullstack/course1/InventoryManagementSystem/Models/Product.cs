using System;

namespace InventoryManagementSystem.Models;

public class Product
{
  public required string Name { get; init; }
  public double Price { get; set; }
  private int _quantity;
  public int Quantity
  {
    get
    {
      return _quantity;
    }
    set
    {
      if (_quantity + value >= 0)
      {
        _quantity += value;
      }
      else
      {
        Console.WriteLine("Final quantity cannot be lower than 0");
      }
    }
  }

  public string AsString() => $"Product name: {Name}, price: ${Price}, qty: {Quantity}";
}
