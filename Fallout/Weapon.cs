using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Weapon : Stuff
    {
        public int DamageBoost { get; set; }
        public Weapon(string name, double value, double weight, int dropchance, int damageBoost)
        {
            this.Name = name;
            this.Value = value;
            this.Weight = weight;
            this.DropChance = dropchance;
            this.DamageBoost = damageBoost;

        }
    }
}
