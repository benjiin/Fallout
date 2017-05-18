using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    [Serializable()]
    class Crap : Stuff
    {
        public Crap(string name, double value, double weight, int dropChance)
        {
            this.Name = name;
            this.Value = value;
            this.Weight = weight;
            this.DropChance = dropChance;
        }








    }
}
