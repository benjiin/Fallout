using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class LivingCreature
    {
        public List<Stuff> Inventory { get; set; }
        public string Name { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Strength { get; set; }
        public int Dodge { get; set; }
        public int MaxHealthPoints { get; set; }
        public int HealthPoints { get; set; }
        public double Money { get; set; }
        public double XrayRadiation { get; set; }
        public int Level { get; set; } 
        public double CarryWeightMax { get; set; }
        public double CarryWeight { get; set; }
        public Room CurrentRoom { get; set; }


    



    }
}
