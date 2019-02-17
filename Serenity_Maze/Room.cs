using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Serenity
{
    public class Room
    {
        

        public Room(int x, int y, int z, string description, bool north, bool east, bool west, bool south, bool up) //all rooms
        {
            // list operations
            Doors = new List<Door>();
            Description = description;
            Doors.Add(new Door("north", north));
            Doors.Add(new Door("east", east));
            Doors.Add(new Door("west", west));
            Doors.Add(new Door("south", south));
            Doors.Add(new Door("up", up));
            Xcoord = x;
            Ycoord = y;
            Zcoord = z;

            Puzzle = false;
            Fight = false;
            PuzzleType = 1;

            bool tavern = (1 == x && 0 == y && 1 == z) ? true : false;
            bool corridor = (1 == x && 1 == y && 1 == z) ? true : false;

            if (!tavern && !corridor)
            {
                Thread.Sleep(50);
                Console.Write("|");
                if (true == IsFight())
                {
                    Puzzle = false;
                    Fight = true;
                }

                if (false == Fight)
                {
                    if (true == IsPuzzle())
                    {
                        Puzzle = true;
                        PuzzleType = GetPuzzleType();
                    }
                }
            }
        }

        public Room()
        {

        }

        public string Description { get; set; }
        public int Xcoord { get; set; }
        public int Ycoord { get; set; }
        public int Zcoord { get; set; }
        //use of composition
        public List<Door> Doors { get; set; }
        public List<Loot> Loots { get; set; }
        public bool Fight { get; set; }
        public bool Puzzle { get; set; }
        public int PuzzleType { get; set; }

        public static bool IsPuzzle()
        {
            Thread.Sleep(100);
            Random rand = new Random();
            int puzzleChance = rand.Next(100);
            bool Puzzle = false;
            if (puzzleChance < 50)
            {
                Puzzle = true;
            }
            return Puzzle;
        }

        public static int GetPuzzleType()
        {
            Random rond = new Random();
            Thread.Sleep(100);
            int RoomSelect = rond.Next(5);
            if (RoomSelect == 0) RoomSelect = 1; 

            return RoomSelect;
        }

        public static bool IsFight()
        {
            Random rand = new Random();
            int fightChance = rand.Next(100);
            bool fight = false;
            if (fightChance < 25)
            {
                fight = true;
            }
            return fight;
        }

    }

}