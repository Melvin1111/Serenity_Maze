using System;
using System.Data;
using System.Data.OleDb;

namespace Serenity
{
    public class NonPlayer
    {
        public NonPlayer(string name, int hitPoints = 100, int attackStrength = 20)
        {
            Name = name;
            HitPoints = 100;
            AttackStrength = 10;
            DefenceStrength = 14;
        }

        //Member Variables
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int AttackStrength { get; set; }
        public int DefenceStrength { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public int CurrentZ { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + " Hit Points: " + HitPoints.ToString() + " Attack Strength: " + AttackStrength.ToString();
        }

        public int DiceRoll(int max)
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, max);
            Console.WriteLine("They rolled a " + dice);
            return dice;
        }

        public bool AttackSuccess(int defence)
        {
            int dice = DiceRoll(20);
            return ((dice) > defence) ? true : false;
        }

        public int Attack(int HitPoints, int DefenceStrength)
        {
            // Attack NPC
            bool attackyn = AttackSuccess(DefenceStrength);
            if (attackyn == true)
            {
                return 10;
            }
            else return 0;

        }

        public void Attacked(int playerAttackValue)
        {
            //attacked by the player
            this.HitPoints = this.HitPoints - playerAttackValue;
        }
    }
}
