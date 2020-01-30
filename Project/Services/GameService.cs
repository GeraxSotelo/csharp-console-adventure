using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }

    public void PrintInstructions()
    {
      Messages.Add($"You are at the {_game.CurrentRoom.Name}\n");
    }

    public void Go(string direction)
    {
      IRoom room = _game.CurrentRoom;
      if (room.Exits.ContainsKey(direction))
      {
        _game.CurrentRoom = room.Exits[direction];

      }
      else
      {
        Messages.Add("Invalid direction");
      }
      Console.Clear();
    }
    public void Help()
    {
      Messages.Add("Type 'go' and the direction to move: 'north' 'south' 'east' 'west'");
      Messages.Add("Type 'take' and item name to take item");
      Messages.Add("Type 'use' and item name to use item");
      Messages.Add("Type 'q', 'quit', or 'exit' to end game.");
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      throw new System.NotImplementedException();
    }

    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
      //   foreach (var item in _game.CurrentRoom.Exits)
      //   {
      //     Console.WriteLine(item.Key + "--" + item.Value.Name);
      //   }
    }
  }
}