using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Weapon : Stuff
    {
        static List<Weapon> AllWeapons = new List<Weapon>();

        public int DamageBoost { get; set; }
        public Weapon(string name, double value, double weight, int dropchance, int damageBoost)
        {
            this.Name = name;
            this.Value = value;
            this.Weight = weight;
            this.DropChance = dropchance;
            this.DamageBoost = damageBoost;
            AllWeapons.Add(this);
        }

        public int GetAllWeapons()
        {
            return AllWeapons.Count();
        }

        public Weapon GetSpecificItem(int index)
        {
            return AllWeapons.ElementAt(index - 1); 
        }
    }
}
