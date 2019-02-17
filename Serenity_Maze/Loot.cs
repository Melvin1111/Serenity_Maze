using System;
using System.Collections.Generic;
using System.Text;

namespace Serenity
{
    public class Loot
    {
        //constructor
        public Loot()
        {

        }
        public Loot(string name, string description, int attack)
        {
            Name = name;
            Description = description;
            AttackModifier = attack;
        }


        //properties
        public string Name { get; set; }
        public string Description { get; set; }
        public int AttackModifier { get; set; }

        //methods

    }
}
