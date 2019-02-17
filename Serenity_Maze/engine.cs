using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serenity
{
    public class Engine
    {
        public Engine()
        {

        }

        const int ATTACK = 20;

        public bool AttackSuccess(int attack, int defence)
        {
            int dice = DiceRoll(ATTACK);
            return ((attack + dice) > defence) ? true : false;
        }

        public int DiceRoll(int max)
        {
            
            Random rnd = new Random();

            int dice = rnd.Next(1, max);
            return dice;
        }
    }
}
