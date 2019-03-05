using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serenity
{
    public class Building
    {
        public Building(string name)
        {
            Rooms = new List<Room>();
            Name = name;

            Loot sword = new Loot("sword", "a stone sword", 2);
            Loot lute = new Loot("lute", "a musical instrument", 0);

            // complex list usage with objects
            List<Loot> impossible = new List<Loot>();
            impossible.Add(sword);

            List<Loot> treasureRoom1 = new List<Loot>();
            treasureRoom1.Add(sword);
            treasureRoom1.Add(lute);

            Rooms.Add(new Room(1, -1, 1, "impossible room", true, true, true, true, true));

//advanced list usage for etire section
            #region FloorOne
            Rooms.Add(new Room(1, 0, 1, "The tavern is grimy, with cobwebs everywhere. A wizened old man is slumped over a table but he perks up as you approach and says 'I think you need to go through the door like all the other adventurers did! Let me know if you find anyone!!'. He then returns to his drink and is forgotten about by everyone.", true, false, false, false, false));
            //row 0
            Rooms.Add(new Room(1, 1, 1, "", true, true, false, true, false));
            Rooms.Add(new Room(2, 1, 1, "the room is moldy the floorboards are damp and the brick walls are mossy", false, true, true, false, false));
            Rooms.Add(new Room(3, 1, 1, "the room is very old with walls bowing in on all sides, a few crumbling stones litter the floor. be carefull not to slip", true, false, true, false, false));
            Rooms.Add(new Room(4, 1, 1, "Somehow its raining in here there is no floor either so you better swim", true, true, false, false, false));
            Rooms.Add(new Room(5, 1, 1, "TREASURE", true, false, true, false, false));
            //row 1
            Rooms.Add(new Room(1, 2, 1, "DEATH", false, true, false, true, false));
            Rooms.Add(new Room(2, 2, 1, "the room is much like the others but there are corpses littering the floor and hanging from the walls and cealing", true, true, true, false, false));
            Rooms.Add(new Room(3, 2, 1, "the walls are made of solid limestone with no bricks present the only light is coming from the open door behind you", false, false, true, true, false));
            Rooms.Add(new Room(4, 2, 1, "the walls are made of a small bassalt brick with runes inlayed in some they glow and pulsate", true, false, false, true, false));
            Rooms.Add(new Room(5, 2, 1, "WARP", false, false, false, true, false));
            //row 2
            Rooms.Add(new Room(1, 3, 1, "DEATH", true, false, false, false, false));
            Rooms.Add(new Room(2, 3, 1, "the walls are made of tea leaves very densly packed to form an indestructable substance", true, false, false, true, false));
            Rooms.Add(new Room(3, 3, 1, "You Win The Game", true, true, false, false, true));
            Rooms.Add(new Room(4, 3, 1, "the room is old with crumbling stone floor and wod plank walls", false, true, true, true, false));
            Rooms.Add(new Room(5, 3, 1, "you cannot see the walls floor or walls everything is black (apart from the doors you can see them)", true, false, true, false, false));
            //row 3
            Rooms.Add(new Room(1, 4, 1, "The room is dark and has an overwhelming stench.", true, true, true, true, false));
            Rooms.Add(new Room(2, 4, 1, "the walls are made of human skin, with eyes and screaming mouths crying out for death.", false, false, true, true, false));
            Rooms.Add(new Room(3, 4, 1, "DEATH", true, true, true, false, false));
            Rooms.Add(new Room(4, 4, 1, "The wall made of ginger bread, layed with various sweets.", true, true, true, false, false));
            Rooms.Add(new Room(5, 4, 1, "the walls are made of hair, weird...", true, false, true, true, false));
            //row 4
            Rooms.Add(new Room(1, 5, 1, "mushrooms, everywhere! squishy and firm, goopy and slimy.", true, true, false, false, false));
            Rooms.Add(new Room(2, 5, 1, "mouths and teeth line the walls, chittering and chattering away.", true, true, false, false, false));
            Rooms.Add(new Room(3, 5, 1, "cardboard walls. eh.", true, true, false, false, false));
            Rooms.Add(new Room(4, 5, 1, "the room defies all logic its like you've walked in to an MC Esher painting", true, true, false, false, false));
            Rooms.Add(new Room(5, 5, 1, "DEATH", true, true, false, false, false));
            #endregion

//public Room(int x, int y, int z, string description, bool north, bool east, bool west, bool south, bool up)

            Rooms.Add(new Room(3, 3, 2, "Welcome to the test", true, true, true, true, true));
            Rooms.Add(new Room(2, 3, 2, "W", true, true, false, true, false));
            Rooms.Add(new Room(4, 3, 2, "E", true, false, true, true, false));
            Rooms.Add(new Room(3, 2, 2, "S", true, true, true, false, false));
            Rooms.Add(new Room(2, 2, 2, "SW", true, true, false, false, false));
            Rooms.Add(new Room(4, 2, 2, "SE", true, false, false, true, false));
            Rooms.Add(new Room(3, 4, 2, "N", false, true, true, true, false));
            Rooms.Add(new Room(2, 4, 2, "NW", false, true, false, true, false));
            Rooms.Add(new Room(4, 4, 2, "NE", false, false, true, true, false));

            Rooms.Add(new Room(3, 3, 3, "there is nothing here", false, false,false,false,false));
        }
        public string Name { get; set; }
        public int NumberOfRooms { get; set; }
        public static List<Room> Rooms { get; set; }
        // composition
        public static Room GetRoom(int x, int y, int z)
        {
            foreach (Room room in Rooms)
            {
                if (x == room.Xcoord && y == room.Ycoord && z == room.Zcoord)
                    return room;
            }
            return new Room();
        }
    }
}