using System;
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
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            //Console.Beep 
            Game game = new Game();

            //game.Ger();
            //game.MovePlayer();
            game.Menu();
            //game.ShowRooms();



            Console.ReadKey();



        }
    }
}
