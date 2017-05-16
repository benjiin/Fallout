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

        /*
        * Menü erstellen und anschliessend mit den jeweiligen Optionen fühlen"
        * Mit ShowOption() wird dann die Option ausgegeben wobei die Zahl farbig hervorgehoben
        * Wird um zudeutlichen was zu drücken ist 
        */
        public void Start()
        {
            Console.SetBufferSize(80, 80);
            Console.SetWindowSize(80, 60);
            MenuBorder(39, 40);
            Menuitem = new List<Option>();
            Option first = new Option('1', "Neues Spiel");
            Menuitem.Add(first);
            Option second = new Option('2', "Spiel Laden");   
            Menuitem.Add(second);                               
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
                    PressAnyKey();
                    break;
                case ConsoleKey.X:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                    PressAnyKey();
                    Start();
                    break;
            }           
        }
        /*
         * Der Dreh und Angelpunkt des Spieles das Spielmenu 
         */
        public void GameMenu()
        {
            Console.Clear();
            if(game.player.CurrentRoom.IsChecked == true)
            {
                Console.WriteLine(game.player.CurrentRoom.Place);
            }
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
                if(game.player.CurrentRoom.Monster.Count != 0 || game.player.CurrentRoom.NPC.Count != 0 && game.player.CurrentRoom.Place != "Vault")
                {
                    Option fight = new Option('6', "Kämpfen");
                    Menuitem.Add(fight);
                }
                if(game.player.CurrentRoom.NPC.Count !=0)
                {
                    Option talk = new Option('7', "Reden");
                    Menuitem.Add(talk);
                }
            }
            if (game.player.CurrentRoom.Place == "Vault")
            {
                Option save = new Option('S', "Speichern");
                Menuitem.Add(save);
            }       
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
                    ShowInventory();
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
                        if (game.player.CurrentRoom.Monster.Count != 0 || game.player.CurrentRoom.NPC.Count != 0 && game.player.CurrentRoom.Place != "Vault")
                        {
                            FightOption();
                        }
                    }
                    break;
                case ConsoleKey.D7:
                    if(game.player.CurrentRoom.IsChecked == true)
                    {
                        if(game.player.CurrentRoom.NPC.Count !=0)
                        {
                            DoSomeWithNPC();
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                    Console.Read();
                    GameMenu();
                    break;
            }
            GameMenu();
        }
        public void DoSomeWithNPC()
        {
            if(game.player.CurrentRoom.NPC != null)
            {
                if (game.player.CurrentRoom.IsChecked == true)
                {
                    Console.Clear();
                    Playerborder();
                    Menuitem = new List<Option>();

                    for (int i = 0; i < game.player.CurrentRoom.NPC.Count; i++)
                    {
                        Option npc = new Option((char)(49 + i), game.player.CurrentRoom.NPC[i].Name);
                        Menuitem.Add(npc);
                    }
                    Option back = new Option('X', "Zurück");
                    Menuitem.Add(back);

                    ShowOption();

                    bool InvalidInput = true;

                    do
                    {
                        ConsoleKeyInfo input = Console.ReadKey();
                        Console.Clear();
                        Playerborder();
                        Menuitem.RemoveRange(0, Menuitem.Count);

                        switch (input.Key)
                        {
                            case ConsoleKey.D1:
                                InteractionWithNPC(game.player.CurrentRoom.NPC[0]);
                                PressAnyKey();
                                InvalidInput = false;
                                break;
                            default:
                                break;
                        }

                    } while (InvalidInput);

                }
            }
        }
        public void InteractionWithNPC(NPC npc)
        {
            if(npc.HealthPoints>0 && game.player.CurrentRoom.NPC != null)
            {
                Console.Clear();
                Menuitem = new List<Option>();
                Option talk = new Option('1', "Rede mit " + npc.Name);
                Menuitem.Add(talk);
                Option use = new Option('2', npc.Ability);
                Menuitem.Add(use);
                Option fight = new Option('3', "Kämpfe gegen " + npc.Name);
                Menuitem.Add(fight);
                Option back = new Option('X', "Zurück");
                Menuitem.Add(back);
                Playerborder();
                ShowOption();
                bool InvalidInput = true;

                do
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    Console.Clear();
                    Menuitem.RemoveRange(0, Menuitem.Count);

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            
                            break;
                            
                        default:
                            
                            break;
                    }

                } while (InvalidInput);
               
                
            }
        }
        /*
         * Überprüfen ob dieser Raum einen Kampfbaren Gegner hat und wenn ja anzeigen lassen und abkämpfen 
         */
        public void FightOption()
        {
            Console.Clear();
            Playerborder();
            Menuitem = new List<Option>();
            if(game.player.CurrentRoom.HasSomeToFight == true)
            {
                /*
                 *Hier vielleicht eine andere Schreibweise an den Tag bringen um mehr Gegner angreifen zu können. 
                 * Aktuell wird nur der erste Index der Liste Monster oder aber NPC abgegriffen.
                 */
                if(game.player.CurrentRoom.Monster.Count != 0)
                {
                    Option attack = new Option('1', game.player.CurrentRoom.Monster[0].Name);
                    Menuitem.Add(attack);
                }
                else if (game.player.CurrentRoom.NPC.Count != 0)
                {
                    Option attack = new Option('1', game.player.CurrentRoom.NPC[0].Name);
                    Menuitem.Add(attack);
                }
            }
            Option back = new Option('X', "Zurück");
            Menuitem.Add(back);
            ShowOption();
            ConsoleKeyInfo input = Console.ReadKey();
            Menuitem.RemoveRange(0, Menuitem.Count);
            Console.Clear();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    if(game.player.CurrentRoom.Monster.Count != 0)
                    {
                        Fight(game.player.CurrentRoom.Monster[0]);
                    }
                    else if(game.player.CurrentRoom.NPC.Count != 0)
                    {
                        Fight(game.player.CurrentRoom.NPC[0]);
                    }
                    break;
                case ConsoleKey.X:
                    GameMenu();
                    break;
                default:
                    break;
            }
        }
        /*
         * Prohejktkriterium Verwertbare Gegenstände 
         */
        public void UseItems()
        {
            Playerborder();
            Menuitem = new List<Option>();
            /*
             * Auch NUR die Potions anzeigen lassen.. Erwähnte ich die geilste Methode HasItem() ?
             * Bedeutet aber auch ich muss die ganze Menu Klasse noch schick machen ;_; 
             */
            if(game.player.Inventory.Count != 0)
            {
                if(game.player.HasPotions())
                {
                    for (int i = 0; i < game.player.Inventory.Count; i++)
                    {
                        if(game.player.Inventory[i].ID == 4)
                        {
                            string itemname = game.player.Inventory[i].Name 
                                + " +" + game.player.Inventory[i].HealthRestore + " HP" 
                                + " +"  + game.player.Inventory[i].Radiation + " Strahlung"
                                + " -" + game.player.Inventory[i].RadiationRestore + " Strahlung";
                            Option stuff = new Option((char)(49 + i), itemname);
                            Menuitem.Add(stuff);
                        }
                    }
                }
            }
            Option back = new Option('X', "Zurück");
            Menuitem.Add(back);
            ShowOption();
            bool InvalidInput = true;
            if(game.player.HasPotions())
            {
                do
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    Console.Clear();
                    Menuitem.RemoveRange(0, Menuitem.Count);

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            EatItem(game.player.Inventory[0]);
                            InvalidInput = false;
                            break;
                        case ConsoleKey.X:
                            GameMenu();
                            break;
                        default:
                            Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                            PressAnyKey();
                            Console.Clear();
                            game.player.GetallInventar();
                            UseItems();
                            break;
                    }
                } while (InvalidInput);

            }
        }
        public void LevelUp()
        {
            if (game.player.Experience >= game.player.NeedExperience)
            {
                game.player.Experience -= game.player.NeedExperience;
                int diceStr = dice.DiceTrow(6),
                    diceDex = dice.DiceTrow(6),
                    diceCon = dice.DiceTrow(6);
                game.player.Level += 1;
                game.player.Strength += diceStr;
                game.player.Dexterity += diceDex;
                game.player.Constitution += diceCon;
                Console.WriteLine("Glückwunsch Du hast einen neuen Level erreicht");
                Console.WriteLine("Deine Stärke hast sich um {0} erhöht und auch deine Geschicklichkeit ist um {1} " +
                    "gestiegen. Ausserdem erhöht sich deine Konstitution um {2} was Dich mehr tragen lässt. Mach weiter " +
                    "so du kleiner Racker.", diceStr, diceDex, diceCon);
            }
        }
        /*
         * JEder muss ja mal was essen.
         */
        public void EatItem(Stuff item)
        {
            int HpRestore;
            if ((game.player.MaxHealthPoints - game.player.HealthPoints) > item.HealthRestore)
            {
                HpRestore = item.HealthRestore;
            }
            else
            {
                HpRestore = (game.player.MaxHealthPoints - game.player.HealthPoints);
            }
            game.player.XrayRadiation += item.Radiation;
            game.player.XrayRadiation -= item.Radiation;
            Console.WriteLine("Du benutzt {0} aus deinen Inventar",item.Name);
            Console.WriteLine("Du heilst dich für {0} HP", HpRestore);
            if(item.Radiation>0)
            {
                Console.WriteLine("Ausserdem erleidest noch {0} Strahlung", item.Radiation);
            }
            if(item.Radiation>0)
            {
                Console.WriteLine("Durch das benutzen von {0} verringert sich deine Strahlung um {1} %", item.Name, item.RadiationRestore);
            }
            game.player.HealthPoints += HpRestore;
            game.player.Inventory.Remove(item);
            PressAnyKey();
        }
        public void ShowInventory()
        {
            Console.Clear();
            game.player.GetallInventar();
            Playerborder();
            Menuitem = new List<Option>();

            Option use = new Option('1', "Benutzen");
            Menuitem.Add(use);
            Option throws = new Option('2', "Fallen lassen");
            Menuitem.Add(throws);
            Option back = new Option('X', "Zurück");
            Menuitem.Add(back);
            ShowOption();
            bool InvalidInput = true;
            do
            {
                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                Menuitem.RemoveRange(0, Menuitem.Count);

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        game.player.GetallInventar();
                        UseItems();

                        break;
                    case ConsoleKey.D2:
                        DropItems();
                        break;
                    case ConsoleKey.X:
                        InvalidInput = false;
                        break;
                    default:
                        Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                        ShowInventory();
                        PressAnyKey();
                        break;
                }

            } while (InvalidInput);

        }
        /*
         * 50/50 Chance, das der Gegner im Raum (nur Monster) Dich angreift 
         */
        public void Enemyattack()
        {
            if (dice.DiceTrow(100) > 50 && game.player.CurrentRoom.Monster.Count != 0)
            {
                Console.WriteLine();
                Console.WriteLine("{0} hat dich im Visier und will kämpfen", game.player.CurrentRoom.Monster[0].Name);
                PressAnyKey();
                Fight(game.player.CurrentRoom.Monster[0]);
            }
        }
        /*
         * Kämpfe laufen unter einen ganz einfachen Schema ab: Zwei Mann geh’n rein, ein Mann geht raus!
         * Es wird mit einem W100 Würfel gewürfelt ,Für den Player gilt seine Stärke *2 muss gleich unter dem Würfel Ergebnis kommen."
         * (z.B. STR = 12, Erfolgreicher Angriff würde dann 24 sein. Sollte der Würfel 1-24 zeigen, gilt der Angriff als Erfolgreich)
         *  Ebenso wie der Spieler können Gegner auch auch Auchweichen Würfeln. Wenn der Ausweichenwurf erfolgreich war (2 * Geschicklichkeit)"
         *  Gilt der vorher erfolgreiche Angriff als parriert.
         */
        public void Fight(LivingCreature creature)
        {
            Console.Clear();
            Playerborder();
            Console.WriteLine("Du kämpst bis aufs Blut Nephalem");
            Console.ReadKey();
            bool alive = true;
            do
            {
                if(game.player.HealthPoints > 0)
                {
                    Console.Clear();
                    MenuBorder(33, 35);
                    Console.SetCursorPosition(0, 34);
                    creature.GetStats(34, 35);
                    Playerborder();
                    Console.WriteLine("Du holst aus...");
                    Thread.Sleep(1500);
                    if (dice.DiceTrow(50) < (game.player.Strength)) 
                    {
                        if (dice.DiceTrow(50) < creature.Dodge)
                        {
                            Console.WriteLine("...doch {0} blockt deinen Angriff", creature.Name);
                            Thread.Sleep(500);
                        }
                        else
                        {
                            int playerDMG = dice.DiceTrow(6);
                            Console.WriteLine("...und triffst {0} für {1} Schaden", creature.Name, playerDMG);
                            Thread.Sleep(500);
                            creature.HealthPoints -= playerDMG;
                            if(creature.HealthPoints <= 0 )
                            {
                                alive = false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("...aber verfehlst {0}", creature.Name);
                        Thread.Sleep(500);
                    }
                    if(creature.HealthPoints > 0)
                    {
                        Console.WriteLine("{0} greift Dich an...", creature.Name);
                        Thread.Sleep(1500);
                        if(dice.DiceTrow(20) < (creature.Strength))
                        {
                            if(dice.DiceTrow(50) < game.player.Dodge)
                            {
                                Console.WriteLine("...Du ({0}) kannst gekonnt blocken", game.player.Name);
                                Thread.Sleep(500);
                            }
                            else
                            {
                                int creatureDMG = dice.DiceTrow(6);
                                Console.WriteLine("...und trifft dich für {0} Schaden", creatureDMG);
                                Thread.Sleep(500);
                                game.player.HealthPoints -= creatureDMG;
                                if(game.player.HealthPoints <= 0)
                                {
                                    alive = false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("...verfehlt Dich aber");
                            Thread.Sleep(500);
                        }
                    }
                    else
                    {
                        alive = false;
                    }
                }
            } while (alive);
            if (creature.HealthPoints <= 0)
            {
                int RewardXP = creature.RewardExperiencePoints;
                if(creature is NPC)
                {
                    //game.player.CurrentRoom.NPC.RemoveAt(0);
                    game.player.CurrentRoom.NPC[0] = null;
                }
                else if(creature is Monster)
                {
                    //game.player.CurrentRoom.Monster.RemoveAt(0);
                    game.player.CurrentRoom.Monster[0] = null;
                }
                Tools bootlecaps;
                Console.WriteLine("Du hast gewonnen");
                Thread.Sleep(1500);
                game.player.CurrentRoom.HasSomeToFight = false;
                Crap Loot = game.allCrap[dice.DiceTrow(game.allCrap.Count)];
                game.player.CurrentRoom.Things.Add(Loot);
                game.player.CurrentRoom.Things.Add(bootlecaps = new Tools("Kronkorken", 1, 100, creature.RewardGold, 2));
                Console.WriteLine("{0}, hat folgenenes fallen gelassen:\n\t+{1}\n\t+{2}({3})", creature.Name, Loot.Name, bootlecaps.Name, bootlecaps.Amount);
                game.player.Experience += creature.RewardExperiencePoints;
                Console.WriteLine("Du erhältst ausserdem {0} Erfahrungspunkte", creature.RewardExperiencePoints);
                LevelUp();
            }
            if(game.player.HealthPoints <= 0)
            {
                Console.WriteLine("Du hast verloren");
                IsDead();
            }
            game.player.CurrentRoom.IsChecked = true;
            PressAnyKey();
        }
        public void PickUpFromContainer(int containerIndex, int itemIndex)
        {
            game.player.AddInventar(game.player.CurrentRoom.Container[containerIndex].HaveStuff[itemIndex]);
            game.player.CurrentRoom.Container[containerIndex].HaveStuff.RemoveAt(itemIndex);
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
                                                    PickUpFromContainer(0, 0);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D2:
                                            if (game.player.CurrentRoom.Container[0].HaveStuff[1] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    PickUpFromContainer(0, 1);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D3:
                                            if (game.player.CurrentRoom.Container[0].HaveStuff[2] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    PickUpFromContainer(0, 2);
                                                }
                                            }
                                            break;
                                        case ConsoleKey.D4:
                                            if (game.player.CurrentRoom.Container[0].HaveStuff[3] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    PickUpFromContainer(0, 3);
                                                }
                                            }
                                            break;
                                            case ConsoleKey.D5:
                                            if (game.player.CurrentRoom.Container[0].HaveStuff[4] != null)
                                            {
                                                if (game.player.CarryWeight < game.player.CarryWeightMax)
                                                {
                                                    PickUpFromContainer(0, 4);
                                                }
                                            }
                                            break;
                                        default:
                                            Console.Clear();
                                            Console.WriteLine("Hier ist nix");
                                            PressAnyKey();
                                            break;
                                    }
                                    OpenContainer();
///////////////////////////////
                                }
                                if(game.player.CurrentRoom.Container[0].Locked == true)
                                {
                                    Console.Clear();
                                    Menuitem.RemoveRange(0, Menuitem.Count);
                                    Console.WriteLine("Abgeschlossen");
                                    PressAnyKey();
                                    Playerborder();
                                    Option lockpick = new Option('1', "Schloss knacken");
                                    if(game.player.HasTools(3))
                                    {
                                        Menuitem.Add(lockpick);
                                    }
                                    Menuitem.Add(back);
                                    ShowOption();
                                    //ConsoleKeyInfo input2 = Console.ReadKey();

                                    switch (input.Key)
                                    {
                                        case ConsoleKey.D1:
                                            if(game.player.HasTools(3))
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
                                                        PressAnyKey();
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
                                            PressAnyKey();
                                            break;
                                    }
                                    PressAnyKey();
                                    OpenContainer();
                                }
                                if (game.player.CurrentRoom.Container[1].Locked == true)
                                {
                                    Console.Clear();
                                    Menuitem.RemoveRange(0, Menuitem.Count);
                                    Console.WriteLine("Abgeschlossen");
                                    PressAnyKey();
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
                                            if (game.player.HasTools(3))
                                            {
                                                game.player.RemoveBobby();
                                                if (dice.DiceTrow(100) < game.player.Dexterity)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Erfolgreich geöffnet");
                                                    game.player.CurrentRoom.Container[1].Locked = false;
                                                    PressAnyKey();
                                                    OpenContainer();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Konnte nicht geöffnet werden");
                                                    PressAnyKey();

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
                                            PressAnyKey();
                                            break;
                                    }
                                    PressAnyKey();
                                    OpenContainer();
                                }
                                if (game.player.CurrentRoom.Container[2].Locked == true)
                                {
                                    Console.Clear();
                                    Menuitem.RemoveRange(0, Menuitem.Count);
                                    Console.WriteLine("Abgeschlossen");
                                    PressAnyKey();
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
                                            if (game.player.HasTools(3))
                                            {
                                                game.player.RemoveBobby();
                                                if (dice.DiceTrow(100) < game.player.Dexterity)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Erfolgreich geöffnet");
                                                    game.player.CurrentRoom.Container[2].Locked = false;
                                                    PressAnyKey();
                                                    OpenContainer();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Konnte nicht geöffnet werden");
                                                    PressAnyKey();
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
                    PressAnyKey();
                    OpenContainer();
                    invalidInput = true;
                }

            } while (invalidInput);
            OpenContainer();
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
                    PressAnyKey();
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

            Console.WriteLine("Du befindest Dich im " + game.player.CurrentRoom.Place);
            if(game.player.CurrentRoom.Description != null)
            {
                Console.WriteLine(game.player.CurrentRoom.Description);
            }
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
        public void DropItems()
        {
            Console.Clear();
            Playerborder();
            Menuitem = new List<Option>();

            if (game.player.Inventory.Count != 0)
            {
                for (int i = 0; i < game.player.Inventory.Count; i++)
                {
                    Option stuff = new Option((char)(49 + i), game.player.Inventory[i].Name);
                    if (game.player.Inventory[i].ID == 3)
                    {
                        stuff.MenuChoice += "(" + game.player.Inventory[i].Amount + ")";
                    }
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
                            if (game.player.Inventory[0] != null)
                            {
                                game.player.CurrentRoom.Things.Add(game.player.Inventory[0]);
                                game.player.RemoveInventar(game.player.Inventory[0]);
                            }
                            break;
                        case ConsoleKey.D2:
                            if (game.player.Inventory[1] != null)
                            {
                                game.player.CurrentRoom.Things.Add(game.player.Inventory[1]);
                                game.player.RemoveInventar(game.player.Inventory[1]);
                            }
                            break;
                        case ConsoleKey.D3:
                            if (game.player.Inventory[2] != null)
                            {
                                game.player.CurrentRoom.Things.Add(game.player.Inventory[2]);
                                game.player.RemoveInventar(game.player.Inventory[2]);
                            }
                            break;
                        case ConsoleKey.D4:
                            if (game.player.Inventory[3] != null)
                            {
                                game.player.CurrentRoom.Things.Add(game.player.Inventory[3]);
                                game.player.RemoveInventar(game.player.Inventory[3]);
                            }
                            break;
                        case ConsoleKey.D5:
                            if (game.player.Inventory[4] != null)
                            {
                                game.player.CurrentRoom.Things.Add(game.player.Inventory[4]);
                                game.player.RemoveInventar(game.player.Inventory[4]);
                            }
                            break;
                        case ConsoleKey.D6:
                            if (game.player.Inventory[4] != null)
                            {
                                game.player.CurrentRoom.Things.Add(game.player.Inventory[5]);
                                game.player.RemoveInventar(game.player.Inventory[5]);
                            }
                            break;
                        case ConsoleKey.D7:
                            if (game.player.Inventory[4] != null)
                            {
                                game.player.CurrentRoom.Things.Add(game.player.Inventory[6]);
                                game.player.RemoveInventar(game.player.Inventory[6]);
                            }
                            break;
                        case ConsoleKey.D8:
                            if (game.player.Inventory[4] != null)
                            {
                                game.player.CurrentRoom.Things.Add(game.player.Inventory[7]);
                                game.player.RemoveInventar(game.player.Inventory[7]);
                            }
                            break;
                        case ConsoleKey.D9:
                            if (game.player.Inventory[4] != null)
                            {
                                game.player.CurrentRoom.Things.Add(game.player.Inventory[8]);
                                game.player.RemoveInventar(game.player.Inventory[8]);
                            }
                            break;
                        case ConsoleKey.X:
                            GameMenu();
                            break;
                        default:
                            Console.WriteLine("Ich habe sie nicht verstanden.");
                            break;
                    }
                    DropItems();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("An dieser Stelle gibt es nix.");
                    PressAnyKey();
                    DropItems();
                    invalidInput = true;
                }
            } while (invalidInput);
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
            IsDead();
            ShowRooms();
            if (game.player.CurrentRoom.IsContaminated == true)
            {
                game.player.XrayRadiation += 0.5;

            }
            if(game.player.XrayRadiation % 5 == 0)
            {
                game.player.HealthPoints -= 1;
            } 
            game.ClearRooms();
            try
            {
                Console.WriteLine("\nWohin möchtest du gehen?");
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
                PressAnyKey();
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
        public void IsDead()
        {
            if(game.player.HealthPoints <= 0)
            {
                Console.Clear();
                Console.WriteLine("Das Spiel ist jetzt vorbei. Ganz toll ");
                PressAnyKey();
                Start();
            }
        }

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
            Console.WriteLine();
            if (game.player.CurrentRoom.NPC.Count != 0)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("NPC:");
                foreach (var item in game.player.CurrentRoom.NPC)
                {
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\t\t+ " + item.Name);
                    Console.ResetColor();
                }
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            ShowRooms();
            Console.WriteLine();
            PressAnyKey();
         //   Enemyattack();
            /////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////
        }
        /*
         * Der erste Menu Entwurf
         */
        public void MenuBorder(int start, int end)
        {
            Console.SetCursorPosition(0, start);
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
            Console.SetCursorPosition(0, end);         
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

            game.player.GetStats(37, 38);
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
            Console.WriteLine("Bitte geben Sie Ihren Namen ein. \n(max 7 Zeichen, keine Leerzeichen oder Zahlen ala xXCuntdestroyer96Xx)");
            game.player.Name = Console.ReadLine();
            if(game.player.Name != string.Empty && game.player.Name.Any(char.IsLetter) && !game.player.Name.Contains(" "))
            {
                game.player.CurrentRoom = game.roomA[3];
                game.player.Home = game.roomB[5];
                Welcome();
            } else
            {
                Console.WriteLine("Nur Buchstaben und keine Leerzeichen");
                PressAnyKey();
                Console.Clear();
                NewPlayer();
            }
        }
        public void PressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Drücken Sie eine beliebe Taste . . .");
            Console.ReadKey();
            Console.ResetColor();
        }
        /*
         * Startbildschirm 
         */
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
            PressAnyKey();
            Console.Clear();
        }


    }
}




