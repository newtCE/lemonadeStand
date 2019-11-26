using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract class RandomValueUser
    {
        public int SelectRandomInt(Random rng,int minimum, int maximum)
        {
            return rng.Next(minimum, maximum);
        }
    }
}
