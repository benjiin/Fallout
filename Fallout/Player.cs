using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Player : Human
    {
        Dice dice = new Dice();

        public Player()
        {
            this.Strength = (dice.DiceTrow(6) + dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Dexterity = (dice.DiceTrow(6) + dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Constitution = (dice.DiceTrow(6) + dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Dodge = this.Dexterity * 2;
            this.MaxHealthPoints = ((this.Strength + this.Constitution) / 2);
            this.HealthPoints = this.MaxHealthPoints;
            this.CarryWeight = ((this.Strength + 10) * 3);
            this.CurrentRoom = this.CurrentRoom;
            this.Level = 1;
        }




    }
}
