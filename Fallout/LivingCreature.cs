using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class LivingCreature
    {
        //public int Intelligence { get; set; }
        //public int Mana { get; set; }
        //public int Apperance { get; set; }
        //public int Knowledge { get; set; }
        //public int Size { get; set; }
        public List<Stuff> Inventory { get; set; }
        public string Name { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Strength { get; set; }
        public int Dodge { get; set; }
        public int MaxHealthPoints { get; set; }
        public int HealthPoints { get; set; }
        public double Money { get; set; }
        public int XrayRadiation { get; set; }
        public int Level { get; set; } 
        public double CarryWeightMax { get; set; }
        public double CarryWeight { get; set; }
        public Room CurrentRoom { get; set; }


        public LivingCreature()
        {

        }

    



    }
}
