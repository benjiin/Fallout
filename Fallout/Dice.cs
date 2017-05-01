using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Dice
    {
        public int Eyes { get; set; }

        public int W6()
        {
            Random rnd = new Random();

            return rnd.Next(1,7);
        }
    }
}
