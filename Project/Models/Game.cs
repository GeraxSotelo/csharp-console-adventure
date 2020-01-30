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
      CurrentRoom = TownEntrance;
    }
  }
}