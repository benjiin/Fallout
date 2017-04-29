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
            Console.WriteLine(game.getRoomName());
            Console.ReadKey();

            //int[][] numbers = new int[4][];
            //numbers[0] = new int[11];
            //numbers[1] = new int[11];
            //numbers[2] = new int[11];
            //numbers[3] = new int[11];

            //for(int i=0; i<numbers[0].Length; i++)
            //{
            //    numbers[0][i] = 1;
            //}

            //foreach (int item in numbers[0])
            //{
            //    Console.WriteLine(item);
            //}



            Console.ReadKey();
        }
    }
}
