﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Serenity
{
    public class Bag
    {
        //constructor
        public Bag()
        {

        }

        public Bag(string label, string description)
        {
            Label = label;
            Description = description;
        }

        public string Label { get; set; }
        public string Description { get; set; }
    }
}


