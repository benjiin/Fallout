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
            for(int i=1; i<1000; i++)
            {
                Console.WriteLine("100 = " + game.dice.DiceTrow(100));
            }
            Console.ReadKey();



        }
    }
}
