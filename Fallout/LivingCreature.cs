using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    [Serializable()]

    abstract class LivingCreature
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
        public double MaxXrayRadiation { get; set; }
        public int Level { get; set; } 
        public double CarryWeightMax { get; set; }
        public double CarryWeight { get; set; }
        public Room CurrentRoom { get; set; }
        public int Experience { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public int ID { get; set; }
        /*
         * Die zu übergebene Methode an alle Klassen, die von dieser erben werden (Monster, player, npc) 
         */
        public abstract void GetStats(int start, int end);
    }
}
