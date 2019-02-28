using System;
using System.Collections.Generic;
using System.Linq;
using ADOX;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Threading;


namespace Serenity
{
    class Program
    {
        
        const string db = "C:\\Users\\gmelv\\Desktop\\zx93\\New folder\\Serenity.accdb";

        static void Main()
        {
            Opening();
            Console.ForegroundColor = ConsoleColor.White;
            BuildDatabase();
            Player player1 = GetPlayerDetails();
            World serenityValley = BuildWorld();
            Room newRoom = Building.GetRoom(1, 0, 1);

            Console.WriteLine("\nPlayer Saved...");
            SavePlayer(player1);
           
            StartGame(player1, serenityValley);
        }

        static void Opening()
        {
            //use of advanced lists
            List<string> title = ASCII_Art.Title();
            foreach (string Title_Line in title)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(Title_Line);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void CharacterCreation()
        {
            
            
            string Name = Console.ReadLine();
        }

        public static Player GetPlayerDetails()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("enter characters name. ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string playerName = (Console.ReadLine());
            Player player1 = new Player(playerName);
            return player1;
        }
            
        

        public static void BuildDatabase()
        {
            //file access algorithm
            ADOX.Catalog cat = new Catalog();
            if (!File.Exists(db))
            {
                cat.Create("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + db + "; Jet OLEDB:Engine Type=5");
                Console.WriteLine("Created database!");
            }
            else
            {
                Console.WriteLine("Loaded...");
            }

        }

        public static void SavePlayer(Player player1)
        {
            int x = player1.CurrentX;
            int y = player1.CurrentY;
            int z = player1.CurrentZ;
            string playerName = player1.Name;
            //database connection 
            String connectionString = @"Provider=Microsoft.JET.OlEDB.4.0; Data Source=" + db + "; Jet OLEDB:Engine Type=5";
            OleDbConnection conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.Connection = conn;
            try
            {
                //user defined data definition query to create databsae
                myCommand.CommandText = "CREATE TABLE SavePlayer(PlayerName TEXT, X TEXT, Y TEXT,Z TEXT,HitPoints TEXT, AttackStrngh TEXT, SaveDate DATE)";
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            
            //user generated sql 
            myCommand.CommandText = "INSERT INTO SavePlayer([PlayerName], X , Y, Z, SaveDate) VALUES (\"" + player1.Name + "\", " + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ", \"" + System.DateTime.Now + "\")";
            //possible secuirty issue: sql injection 
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Auto-saving progress...");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static World BuildWorld()
        {
            //instantiation
            World serenityValley = new World();
            return serenityValley;
        }

        public static void StartGame(Player player1, World serenityValley)
        {
            //instantiaton
            Console.WriteLine(player1);
            Console.WriteLine("You enter a Tavern by a door in the south wall");
            Console.WriteLine("The room has 4 walls [type look to investigate the room and find interactable objects]");
            Room newRoom = Building.GetRoom(1, 0, 1);

            WhatNext(newRoom, player1);

        }
        #region Puzzles
        public static void Puzzle(Player player1, Room currentRoom)
        {
            Console.WriteLine("Puzzling...");
            int typeOfPuzzle = currentRoom.PuzzleType;
            //switch case statement
            switch (typeOfPuzzle)
            {
                case 1:
                    bool SimpleIsFinished = false;
                    string decription = currentRoom.Description;
                    decription += ("\nthere are 3 levers, with the numbers 1-3 writen above them in glowing runes");
                    int x = 1;
                    do
                    {
                        string Input = Console.ReadLine();
                        string input = Input.ToLower();
                        if (input == "look" && x == 1)
                        {
                            x = +1;
                            Console.WriteLine(decription);
                        }
                        else if (input == "look")
                        {
                            Console.WriteLine(decription.ToUpper());
                        }
                        else if (input =="pull lever 1")
                        {
                            Console.WriteLine("5 dead snakes fall out of a shoot in the cealing");
                        }
                        else if (input == "pull lever 3")
                        {
                            Console.WriteLine("arrows start to shoot out of the walls and celing \nit's only a matter of time before they get you");
                            //use of lists
                            List<string> Died = ASCII_Art.Skull();
                            foreach (string Skull_line in Died)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(Skull_line);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.Clear();
                            Main();
                        }
                        else if (input == "pull lever" || input == "Pull corect lever")
                        {
                            Console.WriteLine("it's not that easy");
                        }
                        else if (input == "pull lever 2")
                        {
                            Console.WriteLine("well done the doors are now unlocked");
                            SimpleIsFinished = true;
                            Console.ReadKey();
                        }

                    }
                    while (SimpleIsFinished == false);
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                case 3:
                    Console.WriteLine("Case 3");
                    break;
                case 4:
                    bool OverthinkingIsFinished = false;
                    string description = currentRoom.Description;
                    description += (",\non the east wall there is the word 'overthinking' it has poor kerning but is still ledgable.\nsome of the bricks are a little loose aswell.");
                    x = 1;
                    do
                    {
                        string Input = Console.ReadLine();
                        string input = Input.ToLower();
                        if (input != "open door" && input != "look")
                        {
                            Console.WriteLine("YOU DIED\n(i dont care if this was due to spellng)");
                        }
                        else if (input == "look" && x == 1)
                        {
                            x = +1;
                            Console.WriteLine(description);
                        }
                        else if (input == "look")
                        {
                            Console.WriteLine(description.ToUpper());
                        }
                        else if (input == "open door")
                        {
                            Console.WriteLine("well done you're not an idiot");
                            OverthinkingIsFinished = true;
                            Console.ReadKey();
                        }

                    }
                    while (OverthinkingIsFinished == false);
                    break;
                case 5:
                    Console.WriteLine("Case 5");
                    break;
                default:
                    break;
            }
            //Do puzzle
        }
        #endregion

        public static void Combat(Player player1, NonPlayer nonPlayer, Room currentRoom)
        {
            //complex method with object input parameters
            string input = Console.ReadLine();
            do
            {
                if (input == "attack")
                {
                    //use of object methods
                    nonPlayer.Attacked(player1.Attack(nonPlayer.HitPoints, nonPlayer.DefenceStrength));
                    Console.WriteLine(nonPlayer.HitPoints);
                    input = "bosch";
                }
                if (nonPlayer.HitPoints <= 0)
                {
                    Console.WriteLine(nonPlayer.Name + " is Dead");
                    currentRoom.Fight = false;
                    WhatNext(currentRoom, player1);
                }
                if (input == "bosch")
                {
                    Thread.Sleep(500);
                    player1.Attacked(nonPlayer.Attack(player1.HitPoints, player1.DefenceStrength));
                    Console.WriteLine(player1.HitPoints);
                    input = "attack";
                }
                if (player1.HitPoints <= 0)
                {
                    Console.WriteLine("You died.");
                    Console.ReadKey();
                    Console.Clear();
                    Main();
                    Combat(player1, nonPlayer, currentRoom);
                }
                else if (input != "bosch" && input != "attack")
                {
                    Console.WriteLine("Theres no time for that, you can only attack!");
                    Combat(player1, nonPlayer, currentRoom);
                }
            } while (player1.HitPoints > 0 || nonPlayer.HitPoints > 0);
             
        }

        public static void WhatNext(Room currentRoom, Player player1)
        {

            if (currentRoom.Fight == true)
            {
                NonPlayer nonPlayer = GetnonPlayerDetails();
                Combat(player1, nonPlayer, currentRoom);
            }

            if (currentRoom.Puzzle == true)
            {
                Puzzle(player1, currentRoom);
            }

            string instruction = Console.ReadLine();
            instruction = instruction.ToLower();
            bool isValid = IsValid(instruction);

            if (currentRoom.Description == "DEATH")
            {
                Console.WriteLine("Something lunges out of the darkness and suddenly you are killed.");
                Console.ReadKey();
                Console.WriteLine("You Cannot leave this nightmare");
                Console.ReadKey();
                Console.Clear();
                Main();
            }


            if (!isValid)
            {
                Console.WriteLine("Sorry I don't understand how to " + instruction);
                Console.WriteLine("type help for a list of commands");
                WhatNext(currentRoom, player1);
            }

            List<Door> doors = currentRoom.Doors;
            Door northDoor = doors[0];
            Door eastDoor = doors[1];
            Door westDoor = doors[2];
            Door southDoor = doors[3];
            Door upDoor = doors[4];

            if ("kill self" == instruction)
            {
                List<string> Died = ASCII_Art.Skull();
                foreach(string Skull_line in Died)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Skull_line);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                var Body_Part_1 = new List<string> { "Arm", "Antler", "Leg", "Jaw" };
                var Body_Part_2 = new List<string> { "Face", "Stomache", "Chest", "Heart" };
                //new random used to get true random
                var rnd = new Random();
                string Part_1 = (Body_Part_1[rnd.Next(0, Body_Part_1.Count)]);
                string Part_2 = (Body_Part_2[rnd.Next(0, Body_Part_2.Count)]);

                Console.WriteLine("You rip off your " + $"{Part_1}" + " And stab it into your " + $"{Part_2}" + " repeatedly untill you die from bloodloss.");
                Console.ReadKey();
                Console.WriteLine("You wake up in a cell there is a mutilated corpse in the corner");
            }
            if ("use ladder" == instruction && upDoor.IsExists == true)
            {
                Console.WriteLine("You open the door in the upper wall and walk into a new room.");
                int newX = currentRoom.Xcoord;
                int newY = currentRoom.Ycoord;
                int newZ = currentRoom.Zcoord + 1;
                Room newRoom = Building.GetRoom(newX, newY, newZ);
                player1.CurrentX = newX;
                player1.CurrentY = newY;
                player1.CurrentZ = newZ;
                SavePlayer(player1);
                WhatNext(newRoom, player1);
            }
            if ("go north" == instruction && northDoor.IsExists == true)
            {
                Console.WriteLine("You open the door in the north wall and walk into a new room.");
                int newX = currentRoom.Xcoord;
                int newY = currentRoom.Ycoord + 1;
                int newZ = currentRoom.Zcoord;
                Room newRoom = Building.GetRoom(newX, newY, newZ);
                player1.CurrentX = newX;
                player1.CurrentY = newY;
                player1.CurrentZ = newZ;
                SavePlayer(player1);
                WhatNext(newRoom, player1);
            }

            if ("go east" == instruction && eastDoor.IsExists == true)
            {
                Console.WriteLine("You open the door in the east wall and walk into a new room.");
                int newX = currentRoom.Xcoord + 1;
                int newY = currentRoom.Ycoord;
                int newZ = currentRoom.Zcoord;
                Room newRoom = Building.GetRoom(newX, newY, newZ);
                player1.CurrentX = newX;
                player1.CurrentY = newY;
                player1.CurrentZ = newZ;
                SavePlayer(player1);
                WhatNext(newRoom, player1);
            }

            if ("go west" == instruction && westDoor.IsExists == true)
            {
                Console.WriteLine("You open the door in the west wall and walk into a new room.");
                int newX = currentRoom.Xcoord - 1;
                int newY = currentRoom.Ycoord;
                int newZ = currentRoom.Zcoord;
                Room newRoom = Building.GetRoom(newX, newY, newZ);
                player1.CurrentX = newX;
                player1.CurrentY = newY;
                player1.CurrentZ = newZ;
                SavePlayer(player1);
                WhatNext(newRoom, player1);
            }

            if ("go south" == instruction && southDoor.IsExists == true)
            {
                Console.WriteLine("You open the door in the south wall and walk into a new room.");
                int newX = currentRoom.Xcoord;
                int newY = currentRoom.Ycoord - 1;
                int newZ = currentRoom.Zcoord;
                Room newRoom = Building.GetRoom(newX, newY, newZ);
                player1.CurrentX = newX;
                player1.CurrentY = newY;
                player1.CurrentZ = newZ;
                SavePlayer(player1);
                WhatNext(newRoom, player1);
            }

            if ("go end" == instruction && currentRoom.Zcoord == 1)
            {
                Console.WriteLine("You go to the end of the level.");
                int newX = 3;
                int newY = 3;
                int newZ = 1;
                Room newRoom = Building.GetRoom(newX, newY, newZ);
                player1.CurrentX = newX;
                player1.CurrentY = newY;
                player1.CurrentZ = newZ;
                SavePlayer(player1);
                WhatNext(newRoom, player1);
            }

            if ("look" == instruction) 
            {
                Console.WriteLine(northDoor.IsExists ? "There is a door in the north wall" : "The north wall is blank");
                Console.WriteLine(eastDoor.IsExists ? "There is a door in the east wall" : "The east wall is blank");
                Console.WriteLine(westDoor.IsExists ? "There is a door in the west wall" : "The west wall is blank");
                Console.WriteLine(southDoor.IsExists ? "There is a door in the south wall" : "The south wall is blank");
                Console.WriteLine(upDoor.IsExists ? "There is a ladder leading to a trapdoor in the ceiling" : "");
                WhatNext(currentRoom, player1);
            }
            if ("desc" == instruction)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(currentRoom.Description);
                Console.ForegroundColor = ConsoleColor.White;
                WhatNext(currentRoom, player1);
            }
            else
            {
                Console.WriteLine("Sorry you can't do that!!");
                WhatNext(currentRoom, player1);
            }

        }

        public static bool IsValid(string instruction)
        {
            //list operations
            List<string> valid = new List<string>();
            valid.Add("go north");
            valid.Add("go south");
            valid.Add("go west");
            valid.Add("go east");
            valid.Add("look");
            valid.Add("use ladder");
            valid.Add("attack");
            valid.Add("desc");

            var match = valid.Where(x => x == instruction);
            return (match != null) ? true : false;
        }
        public static NonPlayer GetnonPlayerDetails()
        {
            string playerName = ("Knight");
            NonPlayer nonPlayer = new NonPlayer(playerName);
            return nonPlayer;
        }
    }
}