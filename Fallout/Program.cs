﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Game game = new Game();

            //game.Ger();
            game.MovePlayer();
            //game.ShowRooms();
            //menu.Start();
            Console.ReadKey();


        }

    }
}
