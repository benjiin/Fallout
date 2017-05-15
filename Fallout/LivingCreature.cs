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
        public double MaxXrayRadiation { get; set; }
        public int Level { get; set; } 
        public double CarryWeightMax { get; set; }
        public double CarryWeight { get; set; }
        public Room CurrentRoom { get; set; }
        public int NeedExperience { get; set; }
        public int Experience { get; set; }

        public void GetStats(int start, int end)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(this.Name);
            Console.ResetColor();
            Console.SetCursorPosition(15, start);
            Console.Write("HP: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(this.HealthPoints + "/" + this.MaxHealthPoints);
            Console.ResetColor();
            Console.Write(" STR: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(this.Strength);
            Console.ResetColor();
            Console.Write(" GES: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(this.Dexterity);
            Console.ResetColor();
            Console.Write(" Ausweichen: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(this.Dodge);
            Console.ResetColor();
            Console.Write(" Level: ");
            Console.Write(this.Level);
            Console.Write(" XP: ");
            Console.Write(this.Experience + "/" + this.NeedExperience);
            Console.SetCursorPosition(15, end);
            Console.Write("Gewicht:");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" " + this.CarryWeight + "/" + this.CarryWeightMax);
            Console.ResetColor();
            Console.Write(" Kronkorken: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(this.Money);
            Console.ResetColor();
            Console.Write(" Radiation: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(this.XrayRadiation);
            Console.ResetColor();
        }



    }
}
