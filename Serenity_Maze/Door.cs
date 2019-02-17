using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serenity
{
    public class Door
    {
        public Door(string wall, bool exists)
        {
            Wall = wall;
            IsExists = exists;
            IsLocked = false;
            IsOpen = false;
        }

        public string Wall { get; set; }
        public bool IsExists { get; set; }
        public bool IsLocked { get; set; }
        public bool IsOpen { get; set; }
    }
}
