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
        List<Quest> HasQuest;
        public NPC(Room room)
        {
            this.HasQuest = new List<Quest>();

            this.Strength = (dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Dexterity = (dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Constitution = (dice.DiceTrow(6) + dice.DiceTrow(6));
            this.MaxHealthPoints = ((this.Strength + this.Constitution) / 2);
            this.Dodge = this.Dexterity * 2;
            this.HealthPoints = this.MaxHealthPoints;
            this.CarryWeightMax = double.MaxValue;
            this.CurrentRoom = room;
        }
    }
}
