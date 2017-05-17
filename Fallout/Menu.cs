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
            Console.SetBufferSize(120, 100);
            Console.SetWindowSize(100, 80);
            Welcome();
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
                            case ConsoleKey.X:
                                GameMenu();
                                break;
                            default:
                                Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                                Console.Read();
                                DoSomeWithNPC();
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
                            Talkmaster(game.player.CurrentRoom.NPC[0]);
                            GetQuest();
                            break;
                        case ConsoleKey.D2:
                            UseNPCAbility(npc);
                            break;
                        case ConsoleKey.D3:
                            Fight(npc);
                            break;
                        case ConsoleKey.X:
                            DoSomeWithNPC();
                            break;  
                        default:
                            Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                            Console.Read();
                            InteractionWithNPC(npc);
                            break;
                    }
                } while (InvalidInput);                   
            }
        }
        public void Talkmaster(NPC npc)
        {
            Console.Write("Seid gegrüsst Reisender mein Name ist ");
            Red(npc.Name);
            Console.Write(" (Zeit lassen fuer Lacher. Ich bitte Dich ");
            Green(npc.Quest[0].Name);
            Console.WriteLine(". Auf dich warten grosse Preise");
            Console.ReadKey();
        }
        public void UseNPCAbility(LivingCreature npc)
        {
            Console.Clear();
            Menuitem = new List<Option>();
            if(npc.ID == 1)
            {
                Option healFull = new Option('1', "Komplett heilen (100 Kronkorken)");
                Menuitem.Add(healFull);
                Option cureRad = new Option('2', "Komplette Strahlung entfernen (50 Kronkorken)");
                Menuitem.Add(cureRad);
            }
            if(npc.ID == 2)
            {
                Option buy = new Option('1', "Kaufen");
                Menuitem.Add(buy);
                Option sell = new Option('2', "Verkaufen");
                Menuitem.Add(sell);
            }
            Option back = new Option('X', "Zurück");
            Menuitem.Add(back);   
            Playerborder();
            ShowOption();
            ConsoleKeyInfo input = Console.ReadKey();
            Menuitem.RemoveRange(0, Menuitem.Count);
            bool invalidinput = true;
            do
            {
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        if(npc.ID == 1)
                        {
                            HealNPC();
                            invalidinput = false;
                        }
                        if(npc.ID == 2)
                        {
                            BuyfromNPC();
                        }
                        break;
                    case ConsoleKey.D2:
                        if(npc.ID == 1)
                        {
                            RemoveRad();
                        }
                        if(npc.ID ==2)
                        {
                            SellfromNPC();
                        }
                        break;
                    default:
                        Console.WriteLine("Ich habe Ihre Eingabe nicht verstanden");
                        Console.Read();
                        //UseNPCAbility(npc);
                        break;
                }

            } while (invalidinput);

        }
        public void SellfromNPC()
        {

        }
        public void RemoveRad()
        {

        }
        public void BuyfromNPC()
        {

        }
        public void HealNPC()
        {
            if(game.player.Inventory != null)
            {
                for(int i=0; i <game.player.Inventory.Count; i++)
                {
                    if(game.player.Inventory[i].ID == 2)
                    {
                        if(game.player.Inventory[i].Amount > 0 && game.player.Inventory[i].Amount > 100)
                        {
                            int temp;
                            game.player.Inventory[i].Amount -= 100;
                            temp = game.player.MaxHealthPoints;
                            game.player.HealthPoints = temp;
                        }
                    }
                }

            }
        }
        public void GetQuest()
        {
            Console.Clear();
   
            game.player.QuestLog.Add(game.player.CurrentRoom.NPC[0].Quest[0]);
            game.player.CurrentRoom.NPC[0].Quest[0] = null;
            Playerborder();
            ShowInventory();
        }
        public void Yellow(string color)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(color);
            Console.ResetColor();  
        }
        public void Red(string color)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(color);
            Console.ResetColor();  
        }
        public void Green(string color)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(color);
            Console.ResetColor();
        }
        public void CheckLocationQuest()
        {
            if(game.player.QuestLog.Count != 0)
            {
                foreach (var item in game.player.QuestLog)
                {
                    if(item.CurrentRoom == game.player.CurrentRoom)
                    {
                        item.IsCompleted = true;
                    }
                }      
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
                            Thread.Sleep(800);
                        }
                        else
                        {
                            int playerDMG = dice.DiceTrow(6);
                            Console.WriteLine("...und triffst {0} für {1} Schaden", creature.Name, playerDMG);
                            Thread.Sleep(800);
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
                        Thread.Sleep(800);
                    }
                    if(creature.HealthPoints > 0)
                    {
                        Console.WriteLine("{0} greift Dich an...", creature.Name);
                        Thread.Sleep(1500);
                        if(dice.DiceTrow(20) < (creature.Strength))
                        {
                            if(dice.DiceTrow(50) < game.player.Dodge)
                            {
                                Console.WriteLine("...du kannst gekonnt blocken");
                                Thread.Sleep(800);
                            }
                            else
                            {
                                int creatureDMG = dice.DiceTrow(6);
                                Console.WriteLine("...und trifft dich für {0} Schaden", creatureDMG);
                                Thread.Sleep(800);
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
                            Thread.Sleep(800);
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
                if(creature is NPC)
                {
                    Console.Write(" (Keine XP für Vault Mörder)");
                }
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
            //test

            Console.WriteLine("(Orientierungshilfe) Koordinaten: {0}",game.player.CurrentRoom.Name);


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
         */                                              mkm 
        public void MovePlayer()
        {
            Console.Clear();
            Playerborder();
            ShowRooms();        
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

            if (game.player.CurrentRoom.IsContaminated == true)
            {
                game.player.XrayRadiation += 0.5;
                if (game.player.XrayRadiation % 5 == 0)
                {
                    game.player.HealthPoints -= 1;
                }
            }
            CheckLocationQuest();
            IsDead();


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
            Playerborder();
            ShowRooms();
            Console.WriteLine();
            if (game.player.CurrentRoom.Things.Count != 0)
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
            PressAnyKey();
            //Enemyattack();
            //TODO Rausnehmen

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
        public void GetQuestInfo()
        {
            for(int i=0; i<game.player.QuestLog.Count; i++)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(i +1);
                Console.ResetColor();
                Console.WriteLine("] ");
                Console.SetCursorPosition(14, 28);
                if(game.player.QuestLog[i].IsCompleted)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(game.player.QuestLog[i].Name);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(game.player.QuestLog[i].Name);
                }
                Console.ResetColor();
                Console.Write( "(");
                Yellow(game.player.QuestLog[i].Hint);
                Console.ResetColor();
                Console.Write( ")");
            }
        }
        public void Playerborder()
        {          
            if(game.player.QuestLog.Count != 0)
            {
                Console.SetCursorPosition(0, 27);
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
                Console.SetCursorPosition(0, 28);
                GetQuestInfo();

            }
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
                game.player.CurrentRoom = game.roomB[5];
                game.player.Home = game.roomB[5];
            } else
            {
                Console.WriteLine("Nur Buchstaben und keine Leerzeichen");
                PressAnyKey();
                Console.Clear();
                NewPlayer();
            }
        }
        public void Spoiler(string color)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(color);
            Console.ResetColor();
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
            string s = "WARNUNG";
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
            /*
             * ASCII geliehen von:
             * http://www.asciiworld.com/-Death-Co-.html
             */

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < text.Count; i++)
            {
                Console.WriteLine(text[i]);
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Projektkriterien");
            Green("\nEs soll ein Spiel erstellt werden");
            Console.Write("\nPassiert beim neuen Spiel");
            Green("\nEs soll ein Charakter gespielt werden.");
            Console.Write("\nDieser wird generiert beim neuen Spiel");
            Green("\nDieser Charakter soll verschiedene Attribute / Eigenschaften besitzen");
            Console.Write("\nSind vorhanden. \n- Stärke = (3 * W6 (Würfel mit 6Augen)) \n- Geschicklichkeit 3 * W6 \n- Konstitution 3*W6 \n- Lebenspunkte (Stärke + Konstitution) / 2 \n-Tragegewicht (Stärke + 5) *2 \n- Die selben Werte gelten auch für NPC und Monster, aber nur der Spieler würfelt 3 W6, die anderen nur 2");
            Green("\nDiese Attribute/ Eigenschaften sollen im Spiel relevant sein");
            Console.Write("\ns.O. Geschicklichkeit wird noch für das Ausweichen benutzt bei einem Angriff");
            Green("\nDer Charakter soll sich feldbasierend fortbewegen");
            Console.Write("\n zur Hilfestellung habe ich die \"Koordinaten\" mitgegeben um sich zu orientieren");
            Green("\nEs sollen Gegenstände im Raum und im Inventar existieren (Inventar muss eingesammelt werden)");
            Console.Write("\n Per Zufall wird es im Raum (nur im commomwealth) items geben. Diese werden immer wieder neu generiert, wenn der Spieler zurück in ein Vault geht. Gegenstände können bis zu einer Obergrenze des Gewichtes eingesammelt weden und wieder im aktuellen Raum fallen gelassen werden");
            Green("\nEs sollen Gegenstände verbrauchbar(wie z.B.Tränke) sein");
            Console.Write("\nEs gibt Essen und trinken sowie auch Heiltränke (stimpack) die nicht nur die HP wieder herstellen sondern auch die Strahlung runterziehen können");
            Green("\nEs sollen Gegenstände benutzbar in einem bestimmten Kontext sein");
            Console.Write("\nHaarklammern werden gebraucht um Truhen zu öffnen");
            Red("\nDer Spielstand soll abgespeichert und geladen werden können.");
            Console.Write("\nTODO");
            Green("\nEs sollen friedliche und nicht - friedliche Nicht - Spieler - Charaktere geben.");
            Console.Write("\nIn den Vault gibt es je 2 NPC (einen Arzt und einen nicht Arzt, der Arzt soll einen hochheilen TODO und der andere sol dafür da sein um Sachen zu verkaufen).");
            Green("\nDie nicht-friedlichen Charaktere sollen den Spieler angreifen können.");
            Console.Write("\nIm Commomwealth werden immer wieder Monster generiert sobald man das Commomwealth betritt. Diese können einen auch angreifen oder man hat Glück und kommt so dran vorbei. Donnerkuppel Regel!!! 2 Mann rein, 1 Mann raus. Es wird gekämpft bis zum Tod. Man kann auch NPC angreifen, diese respawnen nicht (\"Er ist Tod Jim\") also wenn keine Lust besteht die Hammer Quest zu beenden ....");
            Green("\nEs soll ein Kampf mit nicht-friedlichen Charakteren möglich sein.");
            Console.Write("\ns.O. TL;DR greif alles an was sich bewegt");
            Green("\nEs soll mindestens eine Handlungslinie existieren, welche abgeschlossen werden kann.");
            Console.Write("\n**********************Spoiler Warnung**********************\n");
            Spoiler(" Gehe von A3, nach dem reden nach A1");
            Spoiler(" Gehe von B1, nach dem reden nach A7");
            Spoiler(" Gehe von B7, nach dem reden nach A3");
            Console.WriteLine();
            PressAnyKey();
            Console.Clear();
             
        }
    }
}                                   