using System;

namespace LibraryManagementSystem;

public static class UserInput
{
  public static string GetStringInput(string message)
  {
    Console.WriteLine(message);
    do
    {
      string? userInputString = Console.ReadLine();
      if (!string.IsNullOrEmpty(userInputString))
      {
        return userInputString.Trim();
      }
      Console.WriteLine("Please, enter a valid string: ");
    } while (true);
  }

  public static int GetIntegerInput(string message, int upperBound)
  {
    while (true)
    {
      if (int.TryParse(Console.ReadLine(), out int userNumber))
      {
        if (userNumber >= 1 && userNumber <= upperBound)
        {
          return userNumber - 1;
        }
        else
        {
          Console.WriteLine($"Select a valid option within the range from 1 to {upperBound}");
        }
      }
      else
      {
        Console.WriteLine("Please, enter a valid integer");
      }
    }
  }
}
