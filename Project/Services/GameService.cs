using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Controllers;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    public IGame _game { get; set; }
    public List<string> Messages { get; set; }
    public bool validate = true;

    public void PrintInstructions()
    {
    }

    /********************GO********************/
    public void Go(string direction)
    {
      IRoom room = _game.CurrentRoom;
      if (room.Exits.ContainsKey(direction))
      {
        _game.CurrentRoom = room.Exits[direction];

        switch (_game.CurrentRoom.Name)
        {
          case "Town Hall":
            TownHall();
            break;
          case "Castle":
            Castle();
            break;
          default:
            break;
        }
      }
      else
      {
        Messages.Add("\nInvalid direction\n");
      }
      Console.Clear();
    }

    /********************HELP********************/
    public void Help()
    {
      Messages.Add("\nType [GO] and the direction to move: [NORTH] [SOUTH] [EAST] [WEST]");
      Messages.Add("Type [LOOK] to look around.");
      Messages.Add("Type [INVENTORY] to check your backpack.");
      Messages.Add("Type [TAKE] and item name to take item");
      Messages.Add("Type [USE] and item name to use item");
      Messages.Add("Type [Q], [QUIT], or [EXIT] to end game.");
    }

    /********************INVENTORY********************/
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

    /********************LOOK********************/
    public void Look()
    {
      IRoom room = _game.CurrentRoom;
      //display exits
      if (room.Exits.Count == 1)
      {
        Messages.Add($"-There is 1 path you can take.-\n");
      }
      else
      {
        Messages.Add($"\n-There are {room.Exits.Count} paths you can take.-\n");
      }
      foreach (var item in room.Exits)
      {
        string str = item.Key.Substring(0, 1).ToUpper() + item.Key.Substring(1);
        Messages.Add($"({str} - {item.Value.Name})");
      }

      if (room.Accessible)
      {
        //display items
        if (room.Items.Count > 0)
        {
          if (room.Items.Count == 1)
          {
            Messages.Add($"\nThere is 1 item in this location.\n");
          }
          else
          {
            Messages.Add($"\nThere are {room.Items.Count} item(s) in this location.\n");
          }
          foreach (var item in room.Items)
          {
            Messages.Add($"-({item.Name} - {item.Description})-");
          }
        }
      }
      else
      {
        Messages.Add("\nYou do not have the ability to view the items in this location.");
      }

    }

    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      validate = false;
    }

    public void Setup(string playerName)
    {
      _game.CurrentPlayer = new Player(playerName);
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
            if (list[i].canTake == true)
            {
              _game.CurrentPlayer.Inventory.Add(list[i]);
              Messages.Add($"You now have a {list[i].Name} in your backpack.");
              list.RemoveAt(i);
              return;
            }
            else
            {
              Messages.Add("This item can not be taken.");
              return;
            }
          }
        }
        Messages.Add("Invalid item");
      }

    }

    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      List<Item> rList = _game.CurrentRoom.Items;
      List<Item> pList = _game.CurrentPlayer.Inventory;
      foreach (var item in rList)
      {
        if (item.Name.ToLower() == itemName)
        {
          _game.CurrentRoom.Accessible = true;
          return;
        }
      }

      // var itemFound = _game.CurrentPlayer.Inventory.Find(i=>i.Name.ToLower()== itemName);
      // if(itemFound == null){
      //   itemFound = _game.CurrentRoom.Items.Find(i=>i.Name.ToLower()== itemName);
      //   if(itemFound == null){
      //     Messages.Add("No such item");
      //     return;
      //   }
      // }
      // _game.CurrentPlayer.Inventory.Remove(itemFound);



      foreach (var item in pList)
      {
        if (item.Name.ToLower() == itemName)
        {
          if (pList.Count <= 0)
          {
            Messages.Add("There are no items in your backpack.");
            return;
          }
          else
          {
            for (int i = 0; i < pList.Count; i++)
            {
              if (pList[i].Name.ToLower() == itemName)
              {
                Messages.Add($"You have used the {pList[i].Name}");
                pList.RemoveAt(i);
              }
            }
            return;
          }
        }
      }
      Messages.Add("Invalid Item");
    }

    public void TownHall()
    {
      Console.Clear();
      Console.WriteLine("--TOWN HALL--\n");
      Console.WriteLine("[A guard walks up to you.]");
      Console.WriteLine("[\"Stop there.\", says the guard. \"Do you have identification?\"]");
      Console.WriteLine("[Yes or No]");
      string answer = Console.ReadLine().ToLower();
      if (answer == "no")
      {
        TownHallExit();
        Reset();
      }
      else if (answer == "yes")
      {
        foreach (var item in _game.CurrentPlayer.Inventory)
        {
          if (item.Name == "Employee ID")
          {
            Messages.Add("[You use the employee ID you found.");
            return;
          }
        }
        Reset();
        Messages.Add("You do not have an ID in your inventory.");
        TownHallExit();
      }
      else if (answer == "q")
      {
        Reset();
      }
      else
      {
        TownHall();
      }
    }

    public void TownHallExit()
    {
      Messages.Add("[The guard says, \"You're not allowed to walk around this town without proper identification\"]");
      Messages.Add("[The guard escorts you out of town.]");
      Messages.Add("[Goodbye.]");
    }

    public void Castle()
    {
      Messages.Add("\n[CONGRATULATIONS!]");
      Messages.Add("[You made it to the castle! The king will see you now.]");
      Messages.Add("\n[Hope you brought a gift  :)]");
      Reset();
    }

    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
  }
}