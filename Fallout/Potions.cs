using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Potions : Stuff
    {

        public Potions(string name, double value, double weight, int dropChance, int radiation, int healthback, int radiationRestore, int id)
        {
            this.Name = name;
            this.Value = value;
            this.Weight = weight;
            this.DropChance = dropChance;
            this.Radiation = radiation;
            this.HealthRestore = healthback;
            this.RadiationRestore = radiationRestore;
            this.ID = id;
        }
    }
}
