﻿using System;
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
            this.Name = Name;
            this.Strength = dice.DiceTrow(3);
            this.CurrentRoom = this.CurrentRoom;
        }




    }
}
