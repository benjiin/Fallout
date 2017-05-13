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
        Dice dice = new Dice();
        public Menu()
        {
            //Welcome();
        }
        /*
        * Menü erstellen und anschliessend mit den jeweiligen Optionen fühlen"
        * Mit ShowOption() wird dann die Option ausgegeben wobei die Zahl farbig hervorgehoben
        * Wird um zudeutlichen was zu drücken ist 
        */
        public void Start()
        {
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
                    Console.WriteLine("Spiel laden in development");
                    Console.ReadKey();
                    break;
                case ConsoleKey.X:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                    Console.ReadKey();
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
            if(game.player.CurrentRoom.IsChecked == true)
            {
                Option move = new Option('3', "Bewegen");
                Menuitem.Add(move);
            }
            if (game.player.CurrentRoom.IsChecked == true)
            {
                if(game.player.CurrentRoom.Things.Count != 0)
                {
                    Option pickup = new Option('4', "Aufheben");
                    Menuitem.Add(pickup);
                }
                if(game.player.CurrentRoom.Container.Count != 0)
                {
                    Option loot = new Option('5', "Behälter öffnen");
                    Menuitem.Add(loot);
                }
                if(game.player.CurrentRoom.Monster.Count != 0)
                {
                Option fight = new Option('6', "Kämpfen");
                Menuitem.Add(fight);
                }
            }
            if (game.player.CurrentRoom.Place == "Vault")
            {
                Option save = new Option('S', "Speichern");
                Menuitem.Add(save);
            }
            Option back = new Option('X', "Zurück");
            Menuitem.Add(back);
            
            ShowOption();

            ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            Menuitem.RemoveRange(0, Menuitem.Count);
            switch (input.Key)
            {
                case ConsoleKey.D1: //durchsuchen
                    SearchRoom();
                    game.player.CurrentRoom.IsChecked = true;
                    break;
                case ConsoleKey.D2: //inventar
                    Console.SetCursorPosition(0, 0);
                    game.player.GetallInventar();
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3: //bewegen
                    if(game.player.CurrentRoom.IsChecked == true)
                    {
                        MovePlayer();
                    }
                    break;
                case ConsoleKey.D4: // pickup
                    if (game.player.CurrentRoom.IsChecked == true)
                    {
                        if(game.player.CurrentRoom.Things.Count != 0)
                        {
                            PickupItems();
                        }
                    }
                    break;
                case ConsoleKey.D5: //öffnen
                    if (game.player.CurrentRoom.IsChecked == true)
                    {
                        if (game.player.CurrentRoom.Container.Count != 0)
                        {
                            OpenContainer();
                        }
                    }
                    break;
                case ConsoleKey.D6: //kämpfen
                    if (game.player.CurrentRoom.IsChecked == true)
                    {
                        if (game.player.CurrentRoom.Monster.Count != 0)
                        {
                            Fight();
                        }
                    }
                    break;
                case ConsoleKey.X:
                    Start();
                    break;
                default:
                    Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                    Console.Read();
                    GameMenu();
                    break;
            }
            GameMenu();
        }
        /*
         * Kämpfe laufen unter einen ganz einfachen Schema ab 2 rein einer raus!"
         * Es wird mit einem W100 Würfel gewürfelt ,Für den Player gilt seine Stärke *2 muss gleich unter dem Würfel Ergebnis kommen."
         * (z.B. STR = 12, Erfolgreicher Angriff würde dann 24 sein. Sollte der Würfel 1-24 zeigen, gilt der Angriff als Erfolgreich)
         *  Ebenso wie der Spieler können Gegner auch auch Auchweichen Würfeln. Wenn der Ausweichenwurf erfolgreich war (2 * Geschicklichkeit)"
         *  Gilt der vorher erfolgreiche Angriff als parriert.
         */
        public void Fight()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            Playerborder();
            Menuitem = new List<Option>();
            bool alive = true;

            if(game.player.CurrentRoom.HasSomeToFight == true)
            {
                Option = new Option('1', game.player.CurrentRoom.Monster.ElementAt(;

            }

        }

        /*
         * Der Raum wird überprüft ob dieser denn auch Container hat. 
         * Beutel und Kisten lassen sich so öffnen, für Truhen aber braucht man Haarklammern.
         * 
         * Wenn man Haarklammern im Besitz hat, wird ein Wurf unter der Geschicklichkeit gewürfelt. Ist dieser Bestanden öffnet sich die Truhe. 
         * Andernfalls bleibt sie geschlossen. In beiden Fällen wird eine Haarklammer aus dem Inventar entfernt.
         */
        public void OpenContainer()
        {
            Console.Clear();
            Playerborder();
            Menuitem = new List<Option>();

            if (game.player.CurrentRoom.Container.Count != 0)
            {
                for (int i = 0; i < game.player.CurrentRoom.Container.Count; i++)
                {
                    Option stuff = new Option((char)(49 + i), game.player.CurrentRoom.Container[i].Name);
                    Menuitem.Add(stuff);
                }
            }
            Option back = new Option('X', "Zurück");
            Menuitem.Add(back);
            ShowOption();

            bool invalidInput = false;
            do
            {

                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                Menuitem.RemoveRange(0, Menuitem.Count);
                invalidInput = false;
                try
                {
                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            if (game.player.CurrentRoom.Container[0] != null)
                            {
                                if (game.player.CurrentRoom.Container[0].Locked == false)
                                {
                                    Playerborder();
                                    for (int i = 0; i < game.player.CurrentRoom.Container[0].HaveStuff.Count; i++)
                                    {
                                        Option stuff = new Option((char)(49 + i), game.player.CurrentRoom.Container[0].HaveStuff[i].Name);
                                        Menuitem.Add(stuff);
                                    }
                                    Menuitem.Add(back);
                                    ShowOption();
                                    switch (input.Key)
                                    {
                                        case ConsoleKey.D1:
                                            if (game.player.CurrentRoom.Container[0].HaveStuff[0] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[0].HaveStuff[0]);
                                                    game.player.CurrentRoom.Container[0].HaveStuff.RemoveAt(0);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D2:
                                            if (game.player.CurrentRoom.Container[0].HaveStuff[1] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[0].HaveStuff[1]);
                                                    game.player.CurrentRoom.Container[0].HaveStuff.RemoveAt(1);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D3:
                                            if (game.player.CurrentRoom.Container[0].HaveStuff[2] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[0].HaveStuff[2]);
                                                    game.player.CurrentRoom.Container[0].HaveStuff.RemoveAt(2);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D4:
                                            if (game.player.CurrentRoom.Container[0].HaveStuff[3] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[0].HaveStuff[3]);
                                                    game.player.CurrentRoom.Container[0].HaveStuff.RemoveAt(3);
                                                }
                                            }
                                            break;
                                            case ConsoleKey.D5:
                                            if (game.player.CurrentRoom.Container[0].HaveStuff[4] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[0].HaveStuff[4]);
                                                    game.player.CurrentRoom.Container[0].HaveStuff.RemoveAt(4);
                                                }
                                            }
                                            break;
                                        default:
                                            Console.Clear();
                                            Console.WriteLine("Hier ist nix");
                                            Console.ReadKey();
                                            break;
                                    }
                                    Console.ReadKey();
                                    OpenContainer();
                                }
                                if(game.player.CurrentRoom.Container[0].Locked == true)
                                {
                                    Console.Clear();
                                    Menuitem.RemoveRange(0, Menuitem.Count);
                                    Console.WriteLine("Abgeschlossen");
                                    Console.ReadKey();
                                    Playerborder();
                                    Option lockpick = new Option('1', "Schloss knacken");
                                    foreach (var item in game.player.Inventory)
                                    {
                                        if(item.ID==3)
                                        {
                                            Menuitem.Add(lockpick);
                                            break; 
                                        }
                                    }
                                    Menuitem.Add(back);
                                    ShowOption();
                                    ConsoleKeyInfo input2 = Console.ReadKey();

                                    switch (input2.Key)
                                    {
                                        case ConsoleKey.D1:
                                            if(game.player.HasBobbypin())
                                            {
                                                game.player.RemoveBobby();
                                                    if (dice.DiceTrow(100) < game.player.Dexterity)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Erfolgreich geöffnet");
                                                        game.player.CurrentRoom.Container[0].Locked = false;
                                                        Console.ReadKey();
                                                        OpenContainer();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Konnte nicht geöffnet werden");
                                                        Console.ReadKey();
                                                }

                                            }  
                                            break;
                                        default:
                                            break;
                                    }
                                }

                            }
                            break;
                        case ConsoleKey.D2:
                            if (game.player.CurrentRoom.Container[1] != null)
                            {
                                if (game.player.CurrentRoom.Container[1].Locked == false)
                                {
                                    Playerborder();
                                    for (int i = 0; i < game.player.CurrentRoom.Container[1].HaveStuff.Count; i++)
                                    {
                                        Option stuff = new Option((char)(49 + i), game.player.CurrentRoom.Container[1].HaveStuff[i].Name);
                                        Menuitem.Add(stuff);
                                    }
                                    Menuitem.Add(back);
                                    ShowOption();
                                    switch (input.Key)
                                    {
                                        case ConsoleKey.D1:
                                            if (game.player.CurrentRoom.Container[1].HaveStuff[0] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[1].HaveStuff[0]);
                                                    game.player.CurrentRoom.Container[1].HaveStuff.RemoveAt(0);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D2:
                                            if (game.player.CurrentRoom.Container[1].HaveStuff[1] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[1].HaveStuff[1]);
                                                    game.player.CurrentRoom.Container[1].HaveStuff.RemoveAt(1);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D3:
                                            if (game.player.CurrentRoom.Container[1].HaveStuff[2] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[1].HaveStuff[2]);
                                                    game.player.CurrentRoom.Container[1].HaveStuff.RemoveAt(2);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D4:
                                            if (game.player.CurrentRoom.Container[1].HaveStuff[3] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[1].HaveStuff[3]);
                                                    game.player.CurrentRoom.Container[1].HaveStuff.RemoveAt(3);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D5:
                                            if (game.player.CurrentRoom.Container[1].HaveStuff[4] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[1].HaveStuff[4]);
                                                    game.player.CurrentRoom.Container[1].HaveStuff.RemoveAt(4);
                                                }
                                            }
                                            break;
                                        default:
                                            Console.Clear();
                                            Console.WriteLine("Hier ist nix");
                                            Console.ReadKey();
                                            break;
                                    }
                                    Console.ReadKey();
                                    OpenContainer();
                                }
                                if (game.player.CurrentRoom.Container[1].Locked == true)
                                {
                                    Console.Clear();
                                    Menuitem.RemoveRange(0, Menuitem.Count);
                                    Console.WriteLine("Abgeschlossen");
                                    Console.ReadKey();
                                    Playerborder();
                                    Option lockpick = new Option('1', "Schloss knacken");
                                    foreach (var item in game.player.Inventory)
                                    {
                                        if (item.ID == 3)
                                        {
                                            Menuitem.Add(lockpick);
                                            break;
                                        }
                                    }
                                    Menuitem.Add(back);
                                    ShowOption();
                                    ConsoleKeyInfo input2 = Console.ReadKey();

                                    switch (input2.Key)
                                    {
                                        case ConsoleKey.D1:
                                            if (game.player.HasBobbypin())
                                            {
                                                game.player.RemoveBobby();
                                                if (dice.DiceTrow(100) < game.player.Dexterity)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Erfolgreich geöffnet");
                                                    game.player.CurrentRoom.Container[1].Locked = false;
                                                    Console.ReadKey();
                                                    OpenContainer();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Konnte nicht geöffnet werden");
                                                    Console.ReadKey();

                                                }

                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }

                            }
                            break;
                        case ConsoleKey.D3:
                            if (game.player.CurrentRoom.Container[2] != null)
                            {
                                if (game.player.CurrentRoom.Container[2].Locked == false)
                                {
                                    Playerborder();
                                    for (int i = 0; i < game.player.CurrentRoom.Container[2].HaveStuff.Count; i++)
                                    {
                                        Option stuff = new Option((char)(49 + i), game.player.CurrentRoom.Container[2].HaveStuff[i].Name);
                                        Menuitem.Add(stuff);
                                    }
                                    Menuitem.Add(back);
                                    ShowOption();
                                    switch (input.Key)
                                    {
                                        case ConsoleKey.D1:
                                            if (game.player.CurrentRoom.Container[2].HaveStuff[0] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[2].HaveStuff[0]);
                                                    game.player.CurrentRoom.Container[2].HaveStuff.RemoveAt(0);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D2:
                                            if (game.player.CurrentRoom.Container[2].HaveStuff[1] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[2].HaveStuff[1]);
                                                    game.player.CurrentRoom.Container[2].HaveStuff.RemoveAt(1);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D3:
                                            if (game.player.CurrentRoom.Container[2].HaveStuff[2] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[2].HaveStuff[2]);
                                                    game.player.CurrentRoom.Container[2].HaveStuff.RemoveAt(2);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D4:
                                            if (game.player.CurrentRoom.Container[2].HaveStuff[3] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[2].HaveStuff[3]);
                                                    game.player.CurrentRoom.Container[2].HaveStuff.RemoveAt(3);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D5:
                                            if (game.player.CurrentRoom.Container[2].HaveStuff[4] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    game.player.AddInventar(game.player.CurrentRoom.Container[2].HaveStuff[4]);
                                                    game.player.CurrentRoom.Container[2].HaveStuff.RemoveAt(4);
                                                }
                                            }
                                            break;
                                        default:
                                            Console.Clear();
                                            Console.WriteLine("Hier ist nix");
                                            Console.ReadKey();
                                            break;
                                    }
                                    Console.ReadKey();
                                    OpenContainer();
                                }
                                if (game.player.CurrentRoom.Container[2].Locked == true)
                                {
                                    Console.Clear();
                                    Menuitem.RemoveRange(0, Menuitem.Count);
                                    Console.WriteLine("Abgeschlossen");
                                    Console.ReadKey();
                                    Playerborder();
                                    Option lockpick = new Option('1', "Schloss knacken");
                                    foreach (var item in game.player.Inventory)
                                    {
                                        if (item.ID == 3)
                                        {
                                            Menuitem.Add(lockpick);
                                            break;
                                        }
                                    }
                                    Menuitem.Add(back);
                                    ShowOption();
                                    ConsoleKeyInfo input2 = Console.ReadKey();

                                    switch (input2.Key)
                                    {
                                        case ConsoleKey.D1:
                                            if (game.player.HasBobbypin())
                                            {
                                                game.player.RemoveBobby();
                                                if (dice.DiceTrow(100) < game.player.Dexterity)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Erfolgreich geöffnet");
                                                    game.player.CurrentRoom.Container[2].Locked = false;
                                                    Console.ReadKey();
                                                    OpenContainer();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Konnte nicht geöffnet werden");
                                                    Console.ReadKey();
                                                }

                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }

                            }
                            break;
                        case ConsoleKey.X:
                            GameMenu();
                            break;
                        default:
                            break;
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("An dieser Stelle gibt es nix.");
                    Console.ReadKey();
                    OpenContainer();
                    invalidInput = true;
                }

            } while (invalidInput);
        }
        /*
         * Items die auf den Boden liegen ins Inventar packen 
         */
        public void PickupItems()
        {
            Console.Clear();
            Playerborder();
            Menuitem = new List<Option>();

                if (game.player.CurrentRoom.Things.Count != 0)
                {
                    for(int i=0; i<game.player.CurrentRoom.Things.Count; i++)
                    {
                        Option stuff = new Option((char)(49 + i), game.player.CurrentRoom.Things[i].Name);
                        if(game.player.CurrentRoom.Things[i].ID == 2 || game.player.CurrentRoom.Things[i].ID == 3)
                        {
                            stuff.MenuChoice += "(" + game.player.CurrentRoom.Things[i].Amount + ")";
                        }
                        Menuitem.Add(stuff);
                    }
                }
                Option back = new Option('X', "Zurück");
                Menuitem.Add(back);
                ShowOption();
            /* 
             * Do While Schleife: Habe sonst eine Argument out of range Exception wenn ich den Index der Liste 
             * wähle wo nix vorhanden ist.
             */
            bool invalidInput = false;
            do
            {
                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                Menuitem.RemoveRange(0, Menuitem.Count);
                invalidInput = false;
                try
                {
                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            if(game.player.CurrentRoom.Things[0] != null)
                            {
                                if(game.player.CarryWeight < game.player.CarryWeightMax)
                                {
                                    game.player.AddInventar(game.player.CurrentRoom.Things[0]);
                                    game.player.CurrentRoom.Things.RemoveAt(0);
                                }
                                else if(game.player.CurrentRoom.Things[0].ID ==2)
                                {
                                    game.player.AddInventar(game.player.CurrentRoom.Things[0]);
                                    game.player.CurrentRoom.Things.RemoveAt(0);
                                }
                            }
                            break;
                        case ConsoleKey.D2:
                            if (game.player.CurrentRoom.Things[1] != null)
                            {
                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                {
                                    game.player.AddInventar(game.player.CurrentRoom.Things[1]);
                                    game.player.CurrentRoom.Things.RemoveAt(1);
                                }
                                else if (game.player.CurrentRoom.Things[1].ID == 2)
                                {
                                    game.player.AddInventar(game.player.CurrentRoom.Things[1]);
                                    game.player.CurrentRoom.Things.RemoveAt(1);
                                }
                            }
                            break;
                        case ConsoleKey.D3:
                            if (game.player.CurrentRoom.Things[2] != null)
                            {
                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                {
                                    game.player.AddInventar(game.player.CurrentRoom.Things[2]);
                                    game.player.CurrentRoom.Things.RemoveAt(2);
                                }
                                else if (game.player.CurrentRoom.Things[2].ID == 2)
                                {
                                    game.player.AddInventar(game.player.CurrentRoom.Things[2]);
                                    game.player.CurrentRoom.Things.RemoveAt(2);
                                }
                            }
                            break;
                        case ConsoleKey.D4:
                            if (game.player.CurrentRoom.Things[3] != null)
                            {
                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                {
                                    game.player.AddInventar(game.player.CurrentRoom.Things[3]);
                                    game.player.CurrentRoom.Things.RemoveAt(3);
                                }
                                else if (game.player.CurrentRoom.Things[3].ID == 2)
                                {
                                    game.player.AddInventar(game.player.CurrentRoom.Things[3]);
                                    game.player.CurrentRoom.Things.RemoveAt(3);
                                }
                            }
                            break;
                        case ConsoleKey.X:
                            GameMenu();
                            break;
                        default:
                            Console.WriteLine("Ich habe sie nicht verstanden.");
                            break;
                    }
                    PickupItems();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("An dieser Stelle gibt es nix.");
                    Console.ReadKey();
                    PickupItems();
                    invalidInput = true;
                }
            } while (invalidInput);
        }
        /*
         * Zeige mir die Nachbar Räume
         */
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
                Console.Write("Im Norden siehst du einen weiteren Raum ");
                if(game.player.CurrentRoom.PathNorth.Description != null)
                {
                    Console.WriteLine("(" + game.player.CurrentRoom.PathNorth.Description + ")");
                }
            }
            if (game.player.CurrentRoom.PathEast != null)
            {
                Console.Write("Im Osten siehst du einen weiteren Raum ");
                if (game.player.CurrentRoom.PathEast.Description != null)
                {
                    Console.WriteLine("(" + game.player.CurrentRoom.PathEast.Description + ")");
                }
            }
            if (game.player.CurrentRoom.PathSouth != null)
            {
                Console.Write("Im Süden siehst du einen weiteren Raum ");
                if (game.player.CurrentRoom.PathSouth.Description != null)
                {
                    Console.WriteLine("(" + game.player.CurrentRoom.PathSouth.Description + ")");
                }
            }
            if (game.player.CurrentRoom.PathWest != null)
            {
                Console.Write("Im Westen siehst du einen weiteren Raum ");
                if (game.player.CurrentRoom.PathWest.Description != null)
                {
                    Console.WriteLine("(" + game.player.CurrentRoom.PathWest.Description + ")");
                }
            }
            if (game.player.CurrentRoom.PathUp != null)
            {
                Console.Write("Über Dir erblickst du einben Ausgang");
                if (game.player.CurrentRoom.PathUp.Description != null)
                {
                    Console.WriteLine("(" + game.player.CurrentRoom.PathUp.Description + ")");
                }
            }
            if (game.player.CurrentRoom.PathDown != null)
            {
                Console.Write("Im Boden Kannst du eine Luke entdecken");
                if (game.player.CurrentRoom.PathDown.Description != null)
                {
                    Console.WriteLine("(" + game.player.CurrentRoom.PathDown.Description + ")");
                }
            }

        }
        /*
         * Bewege den Spieler. 
         * Es wird (nachdem man sich den Raum angeschaut hat) angezeigt in welche Räume man gehen kann. 
         * 
         * Es wird auch noch eine Beschreibung des Raumes gegeben um so "die Quest" zu vollenden.
         */
        public void MovePlayer()
        {
            Console.Clear();
            ShowRooms();
            game.ClearRooms();
            try
            {
                Console.WriteLine("\nWohin möchtest du gehen?");
                if (game.player.CurrentRoom.IsContaminated == true)
                {
                    game.player.XrayRadiation += 0.5;
                }
                if (game.player.CurrentRoom.PathNorth != null)
                {
                    Console.Write("\t\t(");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("↑");
                    Console.ResetColor();
                    Console.WriteLine(")Nord");
                    
                }
                if (game.player.CurrentRoom.PathEast != null && game.player.CurrentRoom.PathWest != null)
                {
                    Console.Write("\t(");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("←");
                    Console.ResetColor();
                    Console.Write(")West\t\t(");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("→");
                    Console.ResetColor();
                    Console.WriteLine(")Ost");
                }
                else if (game.player.CurrentRoom.PathEast != null)
                {
                    Console.Write("\t\t\t(");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("→");
                    Console.ResetColor();
                    Console.WriteLine(")Ost");

                }
                else if (game.player.CurrentRoom.PathWest != null)
                {
                    Console.Write("\t(");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("←");
                    Console.ResetColor();
                    Console.WriteLine(")West");
                }
                if (game.player.CurrentRoom.PathSouth != null)
                {
                    Console.Write("\t\t(");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("↓");
                    Console.ResetColor();
                    Console.WriteLine(")Süd");
                }
                if (game.player.CurrentRoom.PathUp != null)
                {
                    Console.Write("(");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+");
                    Console.ResetColor();
                    Console.WriteLine(")Aufwärts");    
                }
                if (game.player.CurrentRoom.PathDown != null)
                {
                    Console.Write("(");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("-");
                    Console.ResetColor();
                    Console.WriteLine(")Abwärts");  
                }
                //GetStats();
                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine();
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathNorth != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathNorth;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathEast != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathEast;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathSouth != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathSouth;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathWest != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathWest;
                        }
                        break;
                    case ConsoleKey.Add:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathUp != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathUp;
                        }
                        break;
                    case ConsoleKey.Subtract:
                        Console.Clear();
                        if (game.player.CurrentRoom.PathDown != null)
                        {
                            game.player.CurrentRoom = game.player.CurrentRoom.PathDown;
                        }
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
        /*
         * Zeige mir alle Optionen für mein Menu an
         */
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
        /*
         * Den aktuellen Raum nach Gegenständen, Behälter oder Monster absuchen
         * 
         * Erst nachdem ein Raum abgesucht wurde, ist es möglich mit den Raum zu interargieren.
         */
        public void SearchRoom()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("Du guckst um Dich herum und findest");
            for(int i=0; i<8; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }
            Console.Clear();
            ShowRooms();

            Console.WriteLine();
            Console.WriteLine();

            if (game.player.CurrentRoom.Things.Count == 0 && game.player.CurrentRoom.Container.Count == 0 && game.player.CurrentRoom.Monster.Count == 0)
            {
                Console.WriteLine("Nix");
            }
            if(game.player.CurrentRoom.Things.Count != 0)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Müll:");
                foreach (var item in game.player.CurrentRoom.Things)
                {
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (item.ID == 2)
                    {
                        Console.Write("\t\t+ " + item.Name + "(" + item.Amount + ")");
                    }else
                    {
                        Console.Write("\t\t+ " + item.Name);
                    }
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            if(game.player.CurrentRoom.Container.Count != 0)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Behälter:");
                foreach (var item in game.player.CurrentRoom.Container)
                {
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\t\t+ " + item.Name);
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            if(game.player.CurrentRoom.Monster.Count != 0)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Gegner:");
                foreach (var item in game.player.CurrentRoom.Monster)
                {
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\t\t+ " + item.Name);
                    Console.ResetColor();
                }
            }
            Console.ResetColor();
            Console.ReadKey();
        }
        /*
         * Der erste Menu Entwurf
         */
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
        /*
         * Das Menu, welches erstellt wird nachdem es einen Spieler in dem Spiel gibt
         */
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
        /*
         * Das Erstellen eines neuen Spieler und das Festsetzen seines Startpunktes
         */
        public void NewPlayer()
        {
            game = new Game();
            Console.Clear();
            Console.WriteLine("Bitte geben Sie Ihren Namen");
            game.player.Name = Console.ReadLine();
            game.player.CurrentRoom = game.roomG[1];
            game.player.Home = game.roomB[4];

        }
        public void Welcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            string s = "WARNING";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.ResetColor();
            Console.WriteLine("Das folgene Spiel hat den einen oder anderen Bug, geschrieben von Programierer  oder unter der Anleitung von \"Programmierer\". Der Erfinder dieser Grütze und alle die hinter ihm stehen müssen darauf bestehen das keiner dieses Spiel oder ähnliche Bezüge hierraus nachahmt.");
            List<String> text = new List<string>();
            text.Add("\t\t\t\t  _____      ");
            text.Add("\t\t\t\t /      \\    ");
            text.Add("\t\t\t\t|  () () |   ");
            text.Add("\t\t\t\t \\   ^  /   ");
            text.Add("\t\t\t\t  |||||   ");
            text.Add("\t\t\t\t  ||||| ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < text.Count; i++)
            {
                Console.WriteLine(text[i]);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
    }
}




