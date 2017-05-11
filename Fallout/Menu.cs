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
            //Welcome();
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
            Option second = new Option('2', "Spiel Laden");   // Für die letze Option \n um einen Bruch
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
                    GameMenu();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Spiel Laden");
                    Console.WriteLine("Spiel laden");
                    break;
                case ConsoleKey.X:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                    Thread.Sleep(500);
                    Start();
                    break;
            }           
            

            //game.MovePlayer();
        }



        public void GameMenu()
        {
            Console.Clear();
            Playerborder();
            Menuitem = new List<Option>();
            Option search = new Option('1', "Untersuchen");
            Menuitem.Add(search);
            Option inv = new Option('2', "Inventar");
            Menuitem.Add(inv);
            if (game.player.Home == game.player.CurrentRoom)
            {
                Option save = new Option('S', "Speichern");
                Menuitem.Add(save);
            }
            Option move = new Option('3', "Bewegen");
            Menuitem.Add(move);
            if (game.player.CurrentRoom.IsChecked == true)
            {
                Option pickup = new Option('4', "Aufheben");
                Menuitem.Add(pickup);
                Option fight = new Option('5', "Kämpfen");
                Menuitem.Add(fight);
                Option loot = new Option('6', "Öffnen");
                Menuitem.Add(loot);
            }
            Option back = new Option('X', "Zurück");
            Menuitem.Add(back);
            
            ShowOption();

            ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            Menuitem.RemoveRange(0, Menuitem.Count);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    SearchRoom();
                    game.player.CurrentRoom.IsChecked = true;
                    break;
                case ConsoleKey.D2:
                    Console.SetCursorPosition(0, 0);
                    game.player.GetallInventar();
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    MovePlayer();
                    break;
                case ConsoleKey.D4:
                    if(game.player.CurrentRoom.IsChecked == true)
                    {
                        Console.WriteLine();
                    }
                case ConsoleKey.X:
                    Start();
                    break;
                default:
                    Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                    Thread.Sleep(500);
                    GameMenu();
                    break;
            }
            GameMenu();


        }

        //public void Actions()
        //{
        //    Console.Clear();
        //    Playerborder();
        //    Menuitem = new List<Option>();
        //    Option first = new Option('1', "Untersuchen");
        //    Menuitem.Add(first);
        //    Option second = new Option('2', "Bewegen");
        //    Menuitem.Add(second);
        //    if(game.player.CurrentRoom.IsChecked == true)
        //    {
        //        Option pickup = new Option('3', "Aufheben");
        //        Menuitem.Add(pickup);
        //        Option fight = new Option('4', "Kämpfen");
        //        Menuitem.Add(fight);
        //        Option loot = new Option('5', "Öffnen");
        //        Menuitem.Add(loot);
        //    }
        //    Option close = new Option('X', "Zurück");
        //    Menuitem.Add(close);

        //    ShowOption();


        //    ConsoleKeyInfo input = Console.ReadKey();
        //    Console.Clear();
        //    Menuitem.RemoveRange(0, Menuitem.Count);

        //    switch (input.Key)
        //    {
        //        case ConsoleKey.D1:
        //            SearchRoom();
        //            game.player.CurrentRoom.IsChecked = true;
        //            break;
        //        case ConsoleKey.D2:
        //            MovePlayer();
        //            break;
        //        case ConsoleKey.X:
        //            GameMenu();
        //            break;
        //        default:
        //            Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
        //            Thread.Sleep(500);
        //            Actions();
        //            break;
        //    }
        //            Actions();
        //}

        public void MenuBorder()
        {
            Console.SetCursorPosition(0, 39);
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
            
            Console.SetCursorPosition(0, 40);
         
        }
        public void Playerborder()
        {
            
            Console.SetCursorPosition(0, 36);
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
            Console.SetCursorPosition(0, 37);

            game.player.GetStats();
            Console.SetCursorPosition(0, 39);
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

            Console.SetCursorPosition(0, 40);

        }
        public void ShowRooms()
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("Du befindest Dich im " + game.player.CurrentRoom.Place);
            if(game.player.CurrentRoom.Description != null)
            {
                Console.WriteLine(game.player.CurrentRoom.Description);
            }
            Console.WriteLine(game.player.CurrentRoom.Name); // nur zum testen
            if (game.player.CurrentRoom.PathNorth != null)
            {
                Console.Write("Vor Dir siehst du einen weiteren Raum ");
                if(game.player.CurrentRoom.PathNorth.Description != null)
                {
                    Console.WriteLine("(" + game.player.CurrentRoom.PathNorth.Description + ")");
                }
            }
            if (game.player.CurrentRoom.PathEast != null)
            {
                Console.Write("Rechts von Dir siehst du einen weiteren Raum ");
                if (game.player.CurrentRoom.PathEast.Description != null)
                {
                    Console.WriteLine("(" + game.player.CurrentRoom.PathEast.Description + ")");
                }
            }
            if (game.player.CurrentRoom.PathSouth != null)
            {
                Console.Write("Hinter Dir siehst du einen weiteren Raum ");
                if (game.player.CurrentRoom.PathSouth.Description != null)
                {
                    Console.WriteLine("(" + game.player.CurrentRoom.PathSouth.Description + ")");
                }
            }
            if (game.player.CurrentRoom.PathWest != null)
            {
                Console.Write("Links von Dir siehst du einen weiteren Raum ");
                if (game.player.CurrentRoom.PathWest.Description != null)
                {
                    Console.WriteLine("(" + game.player.CurrentRoom.PathWest.Description + ")");
                }
            }

        }
        public void MovePlayer()
        {
            Console.Clear();
            ShowRooms();
            try
            {
                Console.WriteLine("\nWohin möchtest du gehen?");
                if (game.player.CurrentRoom.IsContaminated == true)
                {
                    game.player.XrayRadiation += 0.5;
                }
                if (game.player.CurrentRoom.PathNorth != null)
                {
                    Console.WriteLine("\t\t(↑)Nord");
                }
                if (game.player.CurrentRoom.PathEast != null && game.player.CurrentRoom.PathWest != null)
                {
                    Console.WriteLine("\t(←)West\t\t(→)Ost");
                }
                else if (game.player.CurrentRoom.PathEast != null)
                {
                    Console.WriteLine("\t\t\t(→)Ost");
                }
                else if (game.player.CurrentRoom.PathWest != null)
                {
                    Console.WriteLine("\t(←)West");
                }
                if (game.player.CurrentRoom.PathSouth != null)
                {
                    Console.WriteLine("\t\t(↓)Süd");
                }
                if (game.player.CurrentRoom.PathUp != null)
                {
                    Console.WriteLine("(+)Aufwärts)");    
                }
                if (game.player.CurrentRoom.PathDown != null)
                {
                    Console.WriteLine("(-)Abwärts");  
                }
                //GetStats();
                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine();
                switch (input.Key)
                {
                    case ConsoleKey.N:
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathNorth != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathNorth;
                        }
                        break;
                    case ConsoleKey.E:
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathEast != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathEast;
                        }
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathSouth != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathSouth;
                        }
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathWest != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathWest;
                        }
                        break;
                    case ConsoleKey.U:
                    case ConsoleKey.Add:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathUp != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathUp;
                        }
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.Subtract:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathDown != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathDown;
                        }
                        break;
                    case ConsoleKey.O:
                        Console.Clear();
                        foreach (Stuff item in game.player.CurrentRoom.Container)
                        {
                            if (item is Container)
                            {
                                ((Container)item).GetStuff();
                            }
                        }
                        break;
                    case ConsoleKey.V:
                        Console.Clear();
                        if ((game.player.CurrentRoom.Things.Any()))
                        {
                            game.player.AddInventar(game.player.CurrentRoom.Things[0]);
                            game.RemoveCrap(0);
                        }
                        else
                        {
                            Console.WriteLine("nix hier");
                        }


                        break;
                    case ConsoleKey.I:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Inventar: ");
                        Console.ResetColor();
                        //player.GetallInventar();
                        Console.WriteLine();
                        //GetStats();
                        Console.WriteLine();
                        break;
                    case ConsoleKey.X:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a valid Char");
            }

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
            game.player.CurrentRoom = game.roomB[6];
            game.player.Home = game.roomB[4];
        }
        public void SearchRoom()
        {
            game.player.CurrentRoom.GetStuff();
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




