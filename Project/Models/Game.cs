using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      Player player = new Player("Hobbit");

      Room TownEntrance = new Room("Town Entrance", "Description");
      Room TiriandeAndEnon = new Room("intersection of Tiriande and Enon", "Description");
      Room Inn = new Room("Inn", "Description");
      Room CarpenterShop = new Room("Carpenter Shop", "Description");
      Room TiriandeAndHonione = new Room("intersection of Tiriande and Honione", "Description");
      Room EnonAndRyany = new Room("intersection of Enon and Ryany", "Description");
      Room BlackSmithShop = new Room("Black Smith Shop", "Description");
      Room HonioneAndRyany = new Room("intersection of Honione and Ryany", "Description");
      Room Tavern = new Room("Tavern", "Description");
      Room FisheryShop = new Room("Fishery Shop", "Description");
      Room TownHall = new Room("Town Hall", "Description");
      Room ThenreyAndAnies = new Room("intersection of Thenrey and Anies", "Description");
      Room HilindeAndAnies = new Room("intersection of Hilinde and Anies", "Description");
      Room SylvanTheatre = new Room("Sylvan Theatre", "Description");
      Room LockSmithShop = new Room("Lock Smith Shop", "Description");
      Room Market = new Room("Market", "Description");
      Room Church = new Room("Church", "Description");
      Room TownJail = new Room("Town Jail", "Description");
      Room Castle = new Room("Castle", "Description");

      TownEntrance.AddExit(new Dictionary<string, Room>() { { "north", TiriandeAndEnon } });
      TiriandeAndEnon.AddExit(new Dictionary<string, Room>() { { "north", TiriandeAndHonione }, { "east", CarpenterShop }, { "west", Inn }, { "south", TownEntrance } });
      Inn.AddExit(new Dictionary<string, Room>() { { "north", FisheryShop }, { "east", TownEntrance } });
      CarpenterShop.AddExit(new Dictionary<string, Room>() { { "north", Tavern }, { "west", TiriandeAndEnon }, { "east", EnonAndRyany } });
      TiriandeAndHonione.AddExit(new Dictionary<string, Room>() { { "north", TownHall }, { "south", TiriandeAndEnon }, { "east", Tavern }, { "west", FisheryShop } });
      EnonAndRyany.AddExit(new Dictionary<string, Room>() { { "north", BlackSmithShop }, { "west", CarpenterShop } });
      BlackSmithShop.AddExit(new Dictionary<string, Room>() { { "north", HonioneAndRyany }, { "south", EnonAndRyany } });
      HonioneAndRyany.AddExit(new Dictionary<string, Room>() { { "west", Tavern }, { "south", BlackSmithShop } });
      Tavern.AddExit(new Dictionary<string, Room>() { { "north", HilindeAndAnies }, { "south", CarpenterShop }, { "west", TiriandeAndHonione }, { "east", HonioneAndRyany }, });
      FisheryShop.AddExit(new Dictionary<string, Room>() { { "north", ThenreyAndAnies }, { "south", Inn }, { "east", TiriandeAndHonione } });
      TownHall.AddExit(new Dictionary<string, Room>() { { "north", Market }, { "south", TiriandeAndHonione }, { "west", ThenreyAndAnies }, { "east", HilindeAndAnies } });
      ThenreyAndAnies.AddExit(new Dictionary<string, Room>() { { "north", LockSmithShop }, { "south", FisheryShop }, { "east", TownHall } });
      HilindeAndAnies.AddExit(new Dictionary<string, Room>() { { "north", Church }, { "south", Tavern }, { "west", TownHall }, { "east", SylvanTheatre } });
      SylvanTheatre.AddExit(new Dictionary<string, Room>() { { "west", HilindeAndAnies } });
      LockSmithShop.AddExit(new Dictionary<string, Room>() { { "south", ThenreyAndAnies }, { "east", Market } });
      Market.AddExit(new Dictionary<string, Room>() { { "north", Castle }, { "south", TownHall }, { "west", LockSmithShop }, { "east", Church } });
      Church.AddExit(new Dictionary<string, Room>() { { "south", HilindeAndAnies }, { "west", Market }, { "east", TownJail } });
      TownJail.AddExit(new Dictionary<string, Room>() { { "west", Church } });

      Item waterBottle = new Item("Water Bottle", "Full water bottle. Can you trust it?", true);
      Item key = new Item("Metal Key", "Looks like a door key. It might be useful.", true);

      TownEntrance.Items.Add(waterBottle);
      TownEntrance.Items.Add(key);

      CurrentPlayer = player;
      CurrentRoom = TownEntrance;
    }

    public Game()
    {
      Setup();
    }
  }
}