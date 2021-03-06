using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();
    private bool _running = true;

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      _gameService.PrintInstructions();
      while (_running && _gameService.validate)
      {
        Console.WriteLine($"---{_gameService._game.CurrentRoom.Name.ToUpper()}---");
        Console.WriteLine($"{_gameService._game.CurrentRoom.Description}");
        Print();
        GetUserInput();
      }
      Console.Clear();
      if (!_gameService.validate)
      {
        Print();
      }
      if (!_running)
      {
        Console.WriteLine("\nSafe Travels");
      }
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("\n[Type 'Help' for instructions]\n");
      Console.Write("\n[What would you like to do?] ");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      switch (command)
      {
        case "q":
        case "quit":
        case "exit":
          _running = false;
          break;
        case "help":
          Console.Clear();
          _gameService.Help();
          break;
        case "go":
          _gameService.Go(option);
          _gameService.PrintInstructions();
          break;
        case "look":
          Console.Clear();
          _gameService.Look();
          break;
        case "inventory":
          Console.Clear();
          _gameService.Inventory();
          break;
        case "take":
          Console.Clear();
          _gameService.TakeItem(option);
          break;
        case "use":
          Console.Clear();
          _gameService.UseItem(option);
          break;
        default:
          Console.Clear();
          Console.WriteLine("Invalid input\n");
          break;
      }
    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      foreach (string msg in _gameService.Messages)
      {
        Console.WriteLine(msg);
      }
      _gameService.Messages.Clear();
    }

  }
}