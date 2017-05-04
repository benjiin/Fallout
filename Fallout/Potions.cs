using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Potions : Stuff
    {
        static List<Potions> AllPotions = new List<Potions>();

        public int Radiation { get; set; }
        public int HealthRestore { get; set; }
        public int RadiationRestore { get; set; }
        public Potions(string name, double value, double weight, int dropChance, int radiation, int healthback, int radiationRestore)
        {
            this.Name = name;
            this.Value = value;
            this.Weight = weight;
            this.DropChance = dropChance;
            this.Radiation = radiation;
            this.HealthRestore = healthback;
            this.RadiationRestore = radiationRestore;
            AllPotions.Add(this);
        }

        public int GetAllPotions()
        {
            return AllPotions.Count();
        }

        public Potions GetSpecificItem(int index)
        {
            return AllPotions.ElementAt(index - 1);
        }
    }
}
