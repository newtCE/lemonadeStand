﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract class RandomValueUser
    {
        public int SelectRandomInt(int minimum, int maximum)
        {
            Random rng = new Random();
            return rng.Next(minimum, maximum);
        }
    }
}