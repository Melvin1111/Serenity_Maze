using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serenity
{
    public class World
    {
        public World()
        {
            Buildings = new List<Building>();
            Console.WriteLine("Building Tavern... ");
            Buildings.Add(new Building("Tavern"));
            Console.WriteLine("\nBuilding Maze...");
            Buildings.Add(new Building("Maze"));
        }
        //complex composition
        public List<Building> Buildings { get; set; }
    }
}
