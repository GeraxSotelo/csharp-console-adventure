using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {

    public string Name { get; set; }
    public string Description { get; set; }
    public bool Accessible { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public void AddExit(Dictionary<string, Room> obj)
    {
      foreach (KeyValuePair<string, Room> item in obj)
      {
        Exits.Add(item.Key, item.Value);
      }
    }

    public Room(string name, string description, bool accessible)
    {
      Name = name;
      Description = description;
      Accessible = accessible;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}