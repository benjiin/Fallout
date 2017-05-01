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
            Dice dice = new Dice(); ;
            Game game = new Game();
            dice.W6();
            Console.WriteLine(dice.W6());
            dice.W6();
            Console.WriteLine(dice.W6());
            dice.W6();
            Console.WriteLine(dice.W6());
            Console.ReadKey();



        }
    }
}
