using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool canTake { get; set; }

    public Item(string name, string description, bool canTake)
    {
      Name = name;
      Description = description;
      this.canTake = canTake;
    }
  }
}