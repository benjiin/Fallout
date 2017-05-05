using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Human
    {
        public string Name { get; set; }

        public int Strength { get; set; }
        public int Perception { get; set; }
        public int Endurance { get; set; }
        public int Charisma { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }

        public int Experience { get; set; }
        public int Level { get; set; }

        public int HitPoints { get; set; }
        public int Dodge { get; set; }
        public int ActionPoints { get; set; }
        public double CarryWeight { get; set; }

        public int LifePoint { get; set; }
        public double Money { get; set; }
        public int XrayRadiation { get; set; }
        public Room CurrentRoom { get; set; }
        public List<Stuff> Inventory { get; set; }
        public List<Quest> QuestLog { get; set; }
    }
}
