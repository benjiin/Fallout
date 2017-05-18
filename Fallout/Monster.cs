using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    [Serializable()]
    class Monster : LivingCreature
    {
        Dice dice = new Dice();
        /*
         * Stärke = str + W6
         * Constitution = Stärke + W6
         * MaxHealthPoints = (Stärke + Constitution) / 2
         * 
         */
        public Monster(string name, int str, int dex, int rGold, int xpmult)
        {
            this.Name = name;
            this.Strength = (str + dice.DiceTrow(6));
            this.Constitution = (str + dice.DiceTrow(6));
            this.Dexterity = (dex + dice.DiceTrow(6));
            this.Dodge = (2 * this.Dexterity);
            this.MaxHealthPoints = ((this.Strength + this.Constitution) / 2);
            this.HealthPoints = this.MaxHealthPoints;
            this.RewardGold = Strength + rGold;
            this.RewardExperiencePoints = dice.DiceTrow(Strength) * xpmult;
        }

        public override  void GetStats(int start, int end)
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
