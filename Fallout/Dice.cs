using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    [Serializable()]
    class Dice
    {
        Random rnd = new Random();

        public int DiceTrow(int eyes)
        {
            return rnd.Next(1, eyes+1);
        }
    }
}
