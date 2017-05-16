using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class NPC : LivingCreature
    {
        Dice dice = new Dice();
        public string Ability { get; set; }
        private List<Quest> quest;
        public List<Quest> Quest
        {
            get { return quest; }
            set { quest = value; }
        }

        public NPC(string name, int str, int dex, int con, string abi, int id)
        {
            quest = new List<Quest>();
            this.Strength = (dice.DiceTrow(6) + str);
            this.Dexterity = (dice.DiceTrow(6) + dex);
            this.Constitution = (dice.DiceTrow(6) + con);
            this.MaxHealthPoints = ((this.Strength + this.Constitution) / 2);
            this.Dodge = this.Dexterity * 2;
            this.HealthPoints = this.MaxHealthPoints;
            this.CarryWeightMax = double.MaxValue;
            this.Name = name;
            this.Ability = abi;
            this.ID = id;
        }

        public override void GetStats(int start, int end)
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
        }
    }
}
