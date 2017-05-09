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

        public List<Menuitem> menuitems = new List<Menuitem>();

        public Menu()
        {
            //Welcome();
        }
        public void Start()
        {
            menuitems = new List<Menuitem>();
            menuitems.Add(new Menuitem("Umsehen"));
            menuitems.Add("Bewegen");
            //game.MovePlayer();
        }


        public void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string s = "WARNING";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.ResetColor();
            Console.WriteLine("The following game features bugs performed either by professionals or under the supervision of professionals. Accordingly, MTV and the producers must insist that no one attempt to re-create or re-enact any stunt or activity performed on this game.");
            Console.ReadKey();
            Console.Clear();
        }

    }
}




