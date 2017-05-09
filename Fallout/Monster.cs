using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Monster : LivingCreature
    {
        Dice dice = new Dice();
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }

        /*
         * Stärke = str + W6
         * Constitution = Stärke + W6
         * MaxHealthPoints = (Stärke + Constitution) / 2
         * 
         */
        public Monster(string name, int str, int rGold, int xpmult)
        {
            this.Name = name;
            this.Strength = str + dice.DiceTrow(6);
            this.Constitution = str + dice.DiceTrow(6);
            this.MaxHealthPoints = ((this.Strength + this.Constitution) / 2);
            this.HealthPoints = this.MaxHealthPoints;
            this.RewardGold = Strength + rGold;
            this.RewardExperiencePoints = dice.DiceTrow(Strength) * xpmult;
            
        }

    }
}
