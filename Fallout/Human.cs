using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Human
    {
        //public int Intelligence { get; set; }
        //public int Mana { get; set; }
        //public int Apperance { get; set; }
        //public int Knowledge { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Constitution { get; set; }
        public int Size { get; set; }
        public int Dexterity { get; set; }
        public int Dodge { get; set; }
        public  int LifePoint { get; set; }
        public int HitPoints { get; set; }
        public int Gold { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public double InventoryWeight { get; set; }
        public Room CurrentRoom { get; set; }
        public List<Stuff> Inventory { get; set; }
        public List<Quest> QuestLog { get; set; }

        public Human()
        {
            //this.Intelligence = Intelligence;
            //this.Mana = Mana;
            //this.Apperance = Apperance;
            //this.Knowledge = Knowledge;
            this.Name = Name;
            this.Strength = Strength;
            this.Constitution = Constitution;
            this.Size = Size;
            this.Dexterity = Dexterity;
            this.Dodge = Dodge;
            this.LifePoint = LifePoint;
            this.HitPoints = HitPoints;
            this.InventoryWeight = InventoryWeight;
            this.Gold = Gold;
            this.Experience = Experience;
            this.CurrentRoom = CurrentRoom;
            this.Inventory = Inventory;
            this.QuestLog = QuestLog;
        }

    



    }
}
