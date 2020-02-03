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

      #region -ROOM LIST-
      Room TownEntrance = new Room("Town Entrance", "The only direction to go is North.");
      Room TiriandeAndEnon = new Room("intersection of Tiriande and Enon", "");
      Room Inn = new Room("Inn", "");
      Room CarpenterShop = new Room("Carpenter Shop", "Everyone seems to be busy building furniture and weapon parts.");
      Room TiriandeAndHonione = new Room("intersection of Tiriande and Honione", "");
      Room EnonAndRyany = new Room("intersection of Enon and Ryany", "");
      Room BlackSmithShop = new Room("Black Smith Shop", "");
      Room HonioneAndRyany = new Room("intersection of Honione and Ryany", "");
      Room Tavern = new Room("Tavern", "");
      Room FisheryShop = new Room("Fishery Shop", "Eww, it sure smells fishy in here.");
      Room TownHall = new Room("Town Hall", "");
      Room ThenreyAndAnies = new Room("intersection of Thenrey and Anies", "");
      Room HilindeAndAnies = new Room("intersection of Hilinde and Anies", "");
      Room SylvanTheatre = new Room("Sylvan Theatre", "");
      Room LockSmithShop = new Room("Lock Smith Shop", "It's really dark in here. It must be closed for the day.");
      Room Market = new Room("Market", "");
      Room Church = new Room("Church", "");
      Room TownJail = new Room("Town Jail", "");
      Room Castle = new Room("Castle", "");
      #endregion

      #region -ROOM EXITS-
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
      #endregion

      #region -ITEMS-
      Item waterBottle = new Item("Water Bottle", "A bottle full of clear liquid. Can you trust it?", true);
      Item key = new Item("Metal Key", "Looks like a door key. It might be useful.", true);
      Item employeeId = new Item("Employee ID", "Someone must have lost it.", false);
      Item lightSwitch = new Item("Light Switch", "Let there be light.", false);
      #endregion

      TownEntrance.Items.Add(waterBottle);
      TownEntrance.Items.Add(key);
      TownEntrance.Items.Add(employeeId);
      TownEntrance.Items.Add(lightSwitch);


      CurrentPlayer = player;
      CurrentRoom = TownEntrance;

      Console.WriteLine(@"
__________.__                         .___     .__  .__   
\______   \__|__  __ ____   ____    __| _/____ |  | |  |  
 |       _/  \  \/ // __ \ /    \  / __ |/ __ \|  | |  |  
 |    |   \  |\   /\  ___/|   |  \/ /_/ \  ___/|  |_|  |__
 |____|_  /__| \_/  \___  >___|  /\____ |\___  >____/____/
        \/              \/     \/      \/    \/           ");
      Console.WriteLine("\n--WELCOME TO RIVENDELL--\n");
      Console.WriteLine("\n[You have a meeting with the king.]");
      Console.WriteLine("[He is waiting for you in the castle.]\n");
      Console.WriteLine($"You're at the {CurrentRoom.Name}. {CurrentRoom.Description}");
    }

    public Game()
    {
      Setup();
    }
  }
}