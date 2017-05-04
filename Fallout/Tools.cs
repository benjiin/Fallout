using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Tools : Stuff   
    {
        public Tools(string name, double value, double weight, int dropchance)
        {
            this.Name = name;
            this.Value = value;
            this.Weight = weight;
            this.DropChance = dropchance;
        }
    }
}
