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
        Game game;
        public List<Option> Menuitem { get; set; }

        public Menu()
        {
        }
        public void Start()
        {
            /*
             * Menü erstellen und anschliessend mit den jeweiligen Optionen fühlen"
             * Mit ShowOption() wird dann die Option ausgegeben wobei die Zahl farbig hervorgehoben
             * Wird um zudeutlichen was zu drücken ist 
             */
            MenuBorder();
            Menuitem = new List<Option>();
            Option first = new Option('1', "Neues Spiel");
            Menuitem.Add(first);
            Option second = new Option('2', "Spiel Laden\n");   // Für die letze Option \n um einen Bruch
            Menuitem.Add(second);                               // zu erschaffen... Hilfe ?
            Option close = new Option('X', "Beenden");
            Menuitem.Add(close);
            ShowOption();


            ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            Menuitem.RemoveRange(0, Menuitem.Count);
            switch (input.Key)
            {               
                case ConsoleKey.D1:
                    NewPlayer();
                    NewGame();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Spiel Laden");
                    //game.MovePlayer();
                    break;
                case ConsoleKey.X:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                        break;
            }           
            

                    //game.ShowRooms();
            //game.MovePlayer();
        }



        public void NewGame()
        {
            //Welcome();
            MenuBorder();
            Menuitem = new List<Option>();
            Option first = new Option('1', "Umschauen");
            Menuitem.Add(first);
            ShowOption();

            ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            Menuitem.RemoveRange(0, Menuitem.Count);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    game.ShowRooms();
                    break;
                default:
                    Console.WriteLine();
                    break;
            }


        }
        public void MenuBorder()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 18);
            for (int i = 0; i < Console.WindowWidth - 1; i++)
            {
                if (i == 0 || i == Console.WindowWidth - 2)
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.SetCursorPosition(0, 19);
        }
        public void ShowOption()
        {
            foreach (var item in Menuitem)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item.Index);
                Console.ResetColor();
                Console.WriteLine("] " + item.MenuChoice);
            }
        }
        public void NewPlayer()
        {
            game = new Game();
            Console.Clear();
            Console.WriteLine("Bitte geben Sie Ihren Namen");
            game.player.Name = Console.ReadLine();
            game.player.CurrentRoom = game.roomB[5];
        }
        public void Welcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            string s = "WARNING";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.ResetColor();
            Console.WriteLine("Das folgene Spiel hat den einen oder anderen Bug, geschrieben von Programierer  oder unter der Anleitung von Programmierer. Der Erfinder dieser Grütze und die  Dozentin die hinter ihm stehen müssen darauf bestehen das keiner dieses Spiel oder ähnliche Bezüge hierraus nachahmt.");

            Console.WriteLine('☠'); // Sonderzeichen




            Console.ReadKey();
            Console.Clear();
        }


    }
}




