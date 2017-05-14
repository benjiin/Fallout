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
        List<Quest> Quest;
        public NPC(string name, int str, int dex, int con)
        {
            this.Quest = new List<Quest>();

            this.Strength = (dice.DiceTrow(6) + str);
            this.Dexterity = (dice.DiceTrow(6) + dex);
            this.Constitution = (dice.DiceTrow(6) + con);
            this.MaxHealthPoints = ((this.Strength + this.Constitution) / 2);
            this.Dodge = this.Dexterity * 2;
            this.HealthPoints = this.MaxHealthPoints;
            this.CarryWeightMax = double.MaxValue;
            this.Name = name;
        }
    }
}
