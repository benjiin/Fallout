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
        public List<String> Option { get; set; }
        public bool Run { get; set; } = false;

        public Menu()
        {
            //Welcome();
        }
        public void Start()
        {
            Option = new List<String>();
            Option.Add("1. Umsehen");
            Option.Add("2. Bewegen");
            ShowOption();
            ConsoleKeyInfo input = Console.ReadKey();

            Console.WriteLine();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    game.ShowRooms();
                    break;
                case ConsoleKey.D2:
                    game.MovePlayer();
                    Run = false;
                    break;
                default:
                    Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                        break;
            }
            Start();
            

            //game.MovePlayer();
        }
        public void ShowOption()
        {
            foreach (var item in Option)
            {
                Console.WriteLine(item);
            }
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




