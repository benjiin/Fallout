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
            for(int i=1; i<=100; i++)
            {
                Console.WriteLine(i + ". 100 = " + game.DiceTrow(3));
            }
            Console.ReadKey();



        }
    }
}
