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
      Messages.Add($"\n[You are at the {_game.CurrentRoom.Name}]");
    }

    /********************GO********************/
    public void Go(string direction)
    {
      IRoom room = _game.CurrentRoom;
      if (room.Exits.ContainsKey(direction))
      {
        _game.CurrentRoom = room.Exits[direction];
        Messages.Add($"---{_game.CurrentRoom.Name.ToUpper()}---\n");
      }
      else
      {
        Messages.Add("Invalid direction\n");
      }
      Console.Clear();
    }
    public void Help()
    {
      Messages.Add("Type [GO] and the direction to move: [NORTH] [SOUTH] [EAST] [WEST]");
      Messages.Add("Type [LOOK] to look around.");
      Messages.Add("Type [INVENTORY] to check your backpack.");
      Messages.Add("Type [TAKE] and item name to take item");
      Messages.Add("Type [USE] and item name to use item");
      Messages.Add("Type [Q], [QUIT], or [EXIT] to end game.");
    }

    public void Inventory()
    {
      IPlayer player = _game.CurrentPlayer;
      Messages.Add("---YOUR BACKPACK---\n");
      if (player.Inventory.Count <= 0)
      {
        Messages.Add("Your backpack is empty");
      }
      else
      {
        foreach (Item item in player.Inventory)
        {
          Messages.Add($"({item.Name} - {item.Description})");
        }
      }
    }

    public void Look()
    {
      IRoom room = _game.CurrentRoom;
      Messages.Add($"-There are {room.Exits.Count} paths you can take.-\n");
      foreach (var item in room.Exits)
      {
        string str = item.Key.Substring(0, 1).ToUpper() + item.Key.Substring(1);
        Messages.Add($"({str} - {item.Value.Name})");
      }

      if (room.Items.Count > 0)
      {
        Messages.Add($"\nThere are {room.Items.Count} item(s) in this location.\n");
        foreach (var item in room.Items)
        {
          Messages.Add($"({item.Name} - {item.Description})");
        }
      }
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
      List<Item> list = _game.CurrentRoom.Items;
      if (list.Count <= 0)
      {
        Messages.Add("There are no items in this location.");
      }
      else
      {
        for (int i = 0; i < list.Count; i++)
        {
          if (list[i].Name.ToLower() == itemName)
          {
            _game.CurrentPlayer.Inventory.Add(list[i]);
            Messages.Add($"You now have a {list[i].Name} in your backpack.");
            list.RemoveAt(i);
          }
          else
          {
            Messages.Add("Invalid item");
          }
        }
      }

    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      List<Item> list = _game.CurrentPlayer.Inventory;
      if (list.Count <= 0)
      {
        Messages.Add("There are no items in your backpack.");
      }
      else
      {
        for (int i = 0; i < list.Count; i++)
        {
          if (list[i].Name.ToLower() == itemName)
          {
            Messages.Add($"You have used the {list[i].Name}");
            list.RemoveAt(i);
          }
          else
          {
            Messages.Add("Invalid item");
          }
        }
      }
    }

    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
  }
}