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
            Game game = new Game();
            Console.WriteLine( "CurrentRoom = " + game.GetCurrent());
            Console.Write("Possilbe Location: ");
            game.ShowRooms();
            game.MovePlayer();
            Console.ReadKey();



        }
    }
}
