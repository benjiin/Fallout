using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Player : LivingCreature
    {
        Dice dice = new Dice();
        public List<Quest> QuestLog { get; set; }
        public int Experience { get; set; }
        public Room Home { get; set; }
        public Player()
        {
            this.Inventory = new List<Stuff>();
            this.QuestLog = new List<Quest>();
            this.Strength = (dice.DiceTrow(6) + dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Dexterity = (dice.DiceTrow(6) + dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Constitution = (dice.DiceTrow(6) + dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Dodge = this.Dexterity * 2;
            this.MaxHealthPoints = ((this.Strength + this.Constitution) / 2);
            this.HealthPoints = this.MaxHealthPoints;
            this.CarryWeightMax = ((this.Strength + 5) * 2);
            this.CarryWeight = 0;
            
            this.Level = 1;
            this.Experience = this.Level * 100;
            this.XrayRadiation = 0;
        }


        public void AddInventar(Stuff item)
        {
            if(item is Tools)
            {
                if(item.ID ==2)
                {
                    this.Money += item.Amount;
                }
            }
            else
            {
                if(!(this.CarryWeight > this.CarryWeightMax))
                {
                    this.CarryWeight += item.Weight;
                    this.Inventory.Add(item);
                }
                else
                {
                    Console.WriteLine("Zu schwer");
                }
            }
            
        }

        public void GetallInventar()
        {
            Console.Clear();
            Console.WriteLine("Inventar: ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in this.Inventory)
            {
                Console.WriteLine("\t" + item.Name);
            }
            Console.ResetColor();
        }
        public void GetStats()
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (this.Name.Length > 5)
            {
                Console.Write(this.Name.Substring(0, 5)+ "..");
            }
            else
            {
                Console.Write(this.Name);
            }
            Console.ResetColor();
            Console.Write("\t\tHP: ");
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
            Console.Write(this.Experience);
            Console.WriteLine();
            Console.Write("\t\tGewicht:");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" " +this.CarryWeight + "/" + this.CarryWeightMax);
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
