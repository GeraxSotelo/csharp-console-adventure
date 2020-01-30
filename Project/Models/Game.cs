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
      Room TownEntrance = new Room("Town Entrance", "There is only one road ahead of you going north");
      Room TiriandeAndEnon = new Room("Tiriande and Enon", "There are 4 paths you can take. North to continue on the road. East towards a pottery. West towards a blacksmith. South to return to the town entrance.");
      Room Inn = new Room("Inn", "There are 2 paths you can take. North towards the Fishery Shop. East to return to the intersection of Tiriande and Honione");
      Room CarpenterShop = new Room("Carpenter Shop", "There 3 paths you can take. North towards the Tavern. East to continue on the road. West to return to the intersection of Tiriande and Honione");
      //NOTE fix descriptions below.
      Room TiriandeAndHonione = new Room("Tiriande and Honione", "There are 4 paths you can take. North to continue on the road. East towards a pottery. West towards a blacksmith. South towards the town entrance.");
      Room FisheryShop = new Room("Fishery Shop", "There is only one road ahead of you going north");
      Room LockSmithShop = new Room("Lock Smith Shop", "There is only one road ahead of you going north");
      Room BlackSmithShop = new Room("Black Smith Shop", "There is only one road ahead of you going north");
      Room TownHall = new Room("Town Hall", "There is");
      Room Market = new Room("Market", "There is");
      Room SylvanTheatre = new Room("SylvanTheatre", "There is");

      TownEntrance.AddExit("north", TiriandeAndEnon);
      TiriandeAndEnon.AddExit("south", TownEntrance);

      CurrentRoom = TownEntrance;
    }

    public Game(IRoom currentRoom, IPlayer currentPlayer)
    {
      Setup();
    }
  }
}