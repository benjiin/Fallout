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

            //game.MovePlayer();
            //game.ConsoleMenu();
            //game.ShowRooms();

            foreach (var item in game.roomC)
            {
                Console.WriteLine(item.Name + " " + item.IsContaminated);
            }
            foreach (var item in game.roomD)
            {
                Console.WriteLine(item.Name + " " + item.IsContaminated);
            }
            foreach (var item in game.roomE)
            {
                Console.WriteLine(item.Name + " " + item.IsContaminated);
            }
            foreach (var item in game.roomF)
            {
                Console.WriteLine(item.Name + " " + item.IsContaminated);
            }
            foreach (var item in game.roomG)
            {
                Console.WriteLine(item.Name + " " + item.IsContaminated);
            }



            Console.ReadKey();



        }
    }
}
