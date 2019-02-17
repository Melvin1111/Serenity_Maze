using System;
using System.Collections.Generic;
using System.Text;

namespace Serenity
{
    public class Thing
    {
        //https://stackoverflow.com/questions/7580277/why-use-the-params-keyword
        public Thing(params string[] args)
        {

            List<string> ThingsInThings = new List<string>();
            foreach (var item in args)
            {
                ThingsInThings.Add(item);
            }
        }

        public Thing(List<string> thingList)
        {
            ThingsInThings = thingList;
        }

        public List<string> ThingsInThings { get; set;}
    }
}
