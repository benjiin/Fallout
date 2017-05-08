using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class NPC : Human
    {
        Dice dice = new Dice();
        public NPC(Room room)
        {
            this.Strength = (dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Dexterity = (dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Constitution = (dice.DiceTrow(6) + dice.DiceTrow(6));
            this.MaxHealthPoints = ((this.Strength + this.Constitution) / 2);
            this.HealthPoints = this.MaxHealthPoints;
            this.CarryWeight = double.MaxValue;
            this.CurrentRoom = room;
        }
    }
}
