using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fallout
{
    class Menu 
    {
        Game game = new Game();
        public List<String> Menuitem { get; set; }

        string rectangle = "┌────────────────────────────────┐\n│                                │\n│                                │\n│                                │\n└────────────────────────────────┘";


        public Menu()
        {

        }

        public void Start()
        {

            Console.WriteLine();
            Console.WriteLine(rectangle);

        }

    }
}
