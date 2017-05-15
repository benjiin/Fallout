using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fallout
{
    class Game
    {
        Dice dice = new Dice();
        public Player player = new Player();
        /*
         * 7 Reihen Felder & 11 Spalten in Array gepackt  
         */
        public Room[] roomA = new Room[11];
        public Room[] roomB = new Room[11];
        public Room[] roomC = new Room[11];
        public Room[] roomD = new Room[11];
        public Room[] roomE = new Room[11];
        public Room[] roomF = new Room[11];
        public Room[] roomG = new Room[11];
        public  List<Crap> allCrap = new List<Crap>();
        List<Potions> allPotions = new List<Potions>();
        List<Weapon> allWeapon = new List<Weapon>();
        List<Tools> allTools = new List<Tools>();
        List<NPC> allNPC = new List<NPC>();
        Quest quest = new Quest();
        Tools bobbypin;
        Tools bottlecaps;
        NPC doc;
        NPC follower;
        /*
         * Das Herzstück des Projekt 
         */
        public Game()
        {
            /*
             * Räume erstellen
             * Reihe A und B werden die "Vaults" (Die Schutzräume unabhängig von dem Commonwealth) und Reihe C-G das Commomwealth
             * Spalte 0 1 2 = Vault 1
             * Spalte 3 4 5 6 = Vault 2
             * Spalte 7 8 9 10 = Vault 3
             * 
             *Die Vaults sind NICHT kontaminiert mit der Strahlung während es im Commonwealth zufällig zu Strahlung kommen kann.
             */

            for (int i = 0; i <= 10; i++)
            {
                roomA[i] = new Room("A" + (i));
                roomA[i].Place = "Vault";
                roomB[i] = new Room("B" + (i));
                roomB[i].Place = "Vault";
                roomC[i] = new Room("C" + (i));
                roomC[i].Description = "Ödland";
                if (dice.DiceTrow(100) < 50)
                {
                    roomC[i].IsContaminated = true;
                }
                roomD[i] = new Room("D" + (i));
                roomD[i].Description = "Ödland";
                if (dice.DiceTrow(100) < 50)
                {
                    roomD[i].IsContaminated = true;
                }
                roomE[i] = new Room("E" + (i));
                roomE[i].Description = "Ödland";
                if (dice.DiceTrow(100) < 50)
                {
                    roomE[i].IsContaminated = true;
                }
                roomF[i] = new Room("F" + (i));
                roomF[i].Description = "Ödland";
                if (dice.DiceTrow(100) < 50)
                {
                    roomF[i].IsContaminated = true;
                }
                roomG[i] = new Room("G" + (i));
                roomG[i].Description = "Ödland";
                if (dice.DiceTrow(100) < 50)
                {
                    roomG[i].IsContaminated = true;
                }
            }

            MakeDescription();
            /* 
             * Räume verbinden (Siehe Bild Anhang: Raumplan.png)
             */
            {
                /*
                 * Vault1
                 */
                roomA[0].PathNorth = roomB[0];
                roomA[0].PathEast = roomA[1];

                roomA[1].PathNorth = roomB[1];
                roomA[1].PathEast = roomA[2];
                roomA[1].PathWest = roomA[0];

                roomA[2].PathNorth = roomB[2];
                roomA[2].PathWest = roomA[1];

                roomB[0].PathEast = roomB[1];
                roomB[0].PathSouth = roomA[0];

                roomB[1].PathSouth = roomA[1];
                roomB[1].PathWest = roomB[0];

                roomB[2].PathSouth = roomA[2];
                roomB[2].PathUp = roomG[1];
                /*
                 * Vault2
                 */
                roomA[3].PathNorth = roomB[3];
                roomA[3].PathEast = roomA[4];

                roomA[4].PathNorth = roomB[4];
                roomA[4].PathEast = roomA[5];
                roomA[4].PathWest = roomA[3];

                roomA[5].PathNorth = roomB[5];
                roomA[5].PathEast = roomA[6];
                roomA[5].PathWest = roomA[4];

                roomA[6].PathNorth = roomB[6];
                roomA[6].PathWest = roomA[5];

                roomB[3].PathEast = roomB[4];
                roomB[3].PathSouth = roomA[3];

                roomB[4].PathSouth = roomA[4];
                roomB[4].PathWest = roomB[3];

                roomB[5].PathSouth = roomA[5];

                roomB[6].PathSouth = roomA[6];
                roomB[6].PathUp = roomC[5];
                /* 
                 * Vault 3
                 */
                roomA[7].PathNorth = roomB[7];
                roomA[7].PathEast = roomA[8];

                roomA[8].PathNorth = roomB[8];
                roomA[8].PathEast = roomA[9];
                roomA[8].PathWest = roomA[7];

                roomA[9].PathEast = roomA[10];
                roomA[9].PathWest = roomA[8];

                roomA[10].PathNorth = roomB[10];
                roomA[10].PathWest = roomA[9];

                roomB[7].PathEast = roomB[8];
                roomB[7].PathSouth = roomA[7];

                roomB[8].PathEast = roomB[9];
                roomB[8].PathSouth = roomA[8];
                roomB[8].PathWest = roomB[7];

                roomB[9].PathWest = roomB[8];

                roomB[10].PathSouth = roomA[10];
                roomB[10].PathUp = roomF[9];
                /* 
                 * Commonwealth 
                 */
                roomC[0].PathNorth = roomD[0];
                roomC[0].PathEast = roomC[1];

                roomC[1].PathNorth = roomD[1];
                roomC[1].PathWest = roomC[0];

                roomC[2].PathNorth = roomD[2];
                roomC[2].PathEast = roomC[3];

                roomC[3].PathNorth = roomD[3];
                roomC[3].PathEast = roomC[4];
                roomC[3].PathWest = roomC[2];

                roomC[4].PathNorth = roomD[4];
                roomC[4].PathEast = roomC[5];
                roomC[4].PathWest = roomC[3];

                roomC[5].PathEast = roomC[6];
                roomC[5].PathWest = roomC[4];
                roomC[5].PathDown = roomB[6];

                roomC[6].PathEast = roomC[7];
                roomC[6].PathWest = roomC[5];

                roomC[7].PathEast = roomC[8];
                roomC[7].PathWest = roomC[6];

                roomC[8].PathEast = roomC[9];
                roomC[8].PathWest = roomC[7];

                roomC[9].PathNorth = roomD[9];
                roomC[9].PathEast = roomC[10];
                roomC[9].PathWest = roomC[8];

                roomC[10].PathNorth = roomD[10];
                roomC[10].PathWest = roomC[9];

                roomD[0].PathNorth = roomE[0];
                roomD[0].PathEast = roomD[1];
                roomD[0].PathSouth = roomC[0];

                roomD[1].PathNorth = roomE[1];
                roomD[1].PathWest = roomD[0];
                roomD[1].PathSouth = roomC[1];

                roomD[2].PathNorth = roomE[2];
                roomD[2].PathSouth = roomC[2];

                roomD[3].PathNorth = roomE[3];
                roomD[3].PathSouth = roomC[3];

                roomD[4].PathNorth = roomE[4];
                roomD[4].PathSouth = roomC[4];

                roomD[5].PathNorth = roomE[5];
                roomD[5].PathEast = roomD[6];

                roomD[6].PathEast = roomD[7];
                roomD[6].PathWest = roomD[5];

                roomD[7].PathEast = roomD[8];
                roomD[7].PathWest = roomD[6];

                roomD[8].PathEast = roomD[9];
                roomD[8].PathWest = roomD[7];

                roomD[9].PathNorth = roomE[9];
                roomD[9].PathWest = roomD[8];
                roomD[9].PathSouth = roomC[9];

                roomD[10].PathNorth = roomE[10];
                roomD[10].PathSouth = roomC[10];

                roomE[0].PathNorth = roomF[0];
                roomE[0].PathEast = roomE[1];
                roomE[0].PathSouth = roomD[0];

                roomE[1].PathEast = roomE[2];
                roomE[1].PathSouth = roomD[1];
                roomE[1].PathWest = roomE[0];

                roomE[2].PathNorth = roomF[2];
                roomE[2].PathEast = roomE[3];
                roomE[2].PathSouth = roomD[2];
                roomE[2].PathWest = roomE[1];

                roomE[3].PathEast = roomE[4];
                roomE[3].PathSouth = roomD[3];
                roomE[3].PathWest = roomE[2];

                roomE[4].PathEast = roomE[5];
                roomE[4].PathSouth = roomD[4];
                roomE[4].PathWest = roomE[3];

                roomE[5].PathEast = roomE[6];
                roomE[5].PathSouth = roomD[5];
                roomE[5].PathWest = roomE[4];

                roomE[6].PathNorth = roomF[6];
                roomE[6].PathEast = roomE[7];
                roomE[6].PathWest = roomE[5];

                roomE[7].PathNorth = roomF[7];
                roomE[7].PathEast = roomE[8];
                roomE[7].PathWest = roomE[6];

                roomE[8].PathEast = roomE[9];
                roomE[8].PathWest = roomE[7];

                roomE[9].PathEast = roomE[10];
                roomE[9].PathSouth = roomD[9];
                roomE[9].PathWest = roomE[8];

                roomE[10].PathNorth = roomF[10];
                roomE[10].PathWest = roomE[9];
                roomE[10].PathSouth = roomD[10];

                roomF[0].PathNorth = roomG[0];
                roomF[0].PathEast = roomF[1];
                roomF[0].PathSouth = roomE[0];

                roomF[1].PathEast = roomF[2];
                roomF[1].PathWest = roomF[0];

                roomF[2].PathNorth = roomG[2];
                roomF[2].PathEast = roomF[3];
                roomF[2].PathSouth = roomE[2];
                roomF[2].PathWest = roomF[1];

                roomF[3].PathNorth = roomG[3];
                roomF[3].PathEast = roomF[4];
                roomF[3].PathWest = roomF[2];

                roomF[4].PathNorth = roomG[4];
                roomF[4].PathWest = roomF[3];

                roomF[5].PathNorth = roomG[5];
                roomF[5].PathEast = roomF[6];

                roomF[6].PathEast = roomF[7];
                roomF[6].PathSouth = roomE[6];
                roomF[6].PathWest = roomF[5];

                roomF[7].PathNorth = roomG[7];
                roomF[7].PathEast = roomF[8];
                roomF[7].PathSouth = roomE[7];
                roomF[7].PathWest = roomF[6];

                roomF[8].PathEast = roomF[9];
                roomF[8].PathWest = roomF[7];

                roomF[9].PathEast = roomF[10];
                roomF[9].PathWest = roomF[8];
                roomF[9].PathDown = roomB[10];

                roomF[10].PathNorth = roomG[10];
                roomF[10].PathWest = roomF[9];
                roomF[10].PathSouth = roomE[10];

                roomG[0].PathEast = roomG[1];
                roomG[0].PathSouth = roomF[0];

                roomG[1].PathEast = roomG[2];
                roomG[1].PathWest = roomG[0];
                roomG[1].PathDown = roomB[2];

                roomG[2].PathEast = roomG[3];
                roomG[2].PathSouth = roomF[2];
                roomG[2].PathWest = roomG[1];

                roomG[3].PathEast = roomG[4];
                roomG[3].PathSouth = roomF[3];
                roomG[3].PathWest = roomG[2];

                roomG[4].PathEast = roomG[5];
                roomG[4].PathSouth = roomF[4];
                roomG[4].PathWest = roomG[3];

                roomG[5].PathEast = roomG[6];
                roomG[5].PathSouth = roomF[5];
                roomG[5].PathWest = roomG[4];

                roomG[6].PathEast = roomG[7];
                roomG[6].PathWest = roomG[5];

                roomG[7].PathEast = roomG[8];
                roomG[7].PathSouth = roomF[7];
                roomG[7].PathWest = roomG[6];

                roomG[8].PathEast = roomG[9];
                roomG[8].PathWest = roomG[7];

                roomG[9].PathEast = roomG[10];
                roomG[9].PathWest = roomG[8];

                roomG[10].PathSouth = roomF[10];
                roomG[10].PathWest = roomG[9];

                /*
                 * Crap-Item erstellen (Müll nur zum verkaufen gedacht)
                 * 
                 * Liste die gleich alle Items auffängt und so verarbeiter macht
                 * 
                 * Crap = Name, Wert der Einheit, Gewicht der Einheit, DropChance
                 * 
                 */
                Crap alarmClock = new Crap("Alter Wecker", 10, 1, 90);
                allCrap.Add(alarmClock);
                Crap aluminiumCan = new Crap("Aluminium Dose", 1, 1, 80);
                allCrap.Add(aluminiumCan);
                Crap babyrattle = new Crap("Babyrassel", 2, 5, 98);
                allCrap.Add(babyrattle);
                Crap dogtag = new Crap("Hundemarke", 1, 2, 90);
                allCrap.Add(dogtag);
                Crap paper = new Crap("Papier", 1, 1, 75);
                allCrap.Add(paper);
                Crap goldwatch = new Crap("Goldene Uhr", 40, 5, 20);
                allCrap.Add(goldwatch);
                Crap heatplate = new Crap("Herdplatte", 4, 3, 94);
                allCrap.Add(heatplate);
                Crap lightbulb = new Crap("Glühbirne", 3, 5, 94);
                allCrap.Add(lightbulb);
                Crap oilcanister = new Crap("Ölkanister", 12, 3, 96);
                allCrap.Add(oilcanister);
                Crap packofcigarette = new Crap("Zigarettenschachtel", 12, 1, 99);
                allCrap.Add(packofcigarette);
                Crap skull = new Crap("Menschlicher Schädel", 1, 2, 80);
                allCrap.Add(skull);
                Crap sandclock = new Crap("Kaputte Sanduhr", 1, 1, 90);
                allCrap.Add(sandclock);
                /* 
                 * Potions/Verbrauchsgüter = Stimpack(Tränke), Essen(verseucht)
                 * 
                 * Potions = Name, Wert der Einheit, Gewicht pro Einheit, DropChance, Hinzugefügte Strahlung, Hergestellte HP, Strahlung reduzieren
                 *  
                 */
                Potions carrot = new Potions("Verstrahlte Karotte", 3, 1, 90, 3, 3, 0, 4);
                allPotions.Add(carrot);
                Potions corn = new Potions("Verstrahlter Maiskolben", 3, 1, 90, 6, 3, 0, 4);
                allPotions.Add(corn);
                Potions tomato = new Potions("Verstrahlte Tomate", 3, 1, 90, 4, 3, 0, 4);
                allPotions.Add(tomato);
                Potions stimpack = new Potions("Stimpack", 25, 0, 55, 0, 5, 0, 4);
                allPotions.Add(stimpack);
                Potions beer = new Potions("Flasche Bier", 5, 1, 70, 0, 2, 5, 4);
                allPotions.Add(beer);
                Potions radaway = new Potions("Radaway", 20, 0, 50, 0, 0, 10, 4);
                allPotions.Add(radaway);
                /*
                 * Weapons  Einfache Waffen, erstmal ohne Schusswaffen sondern nur Verbesseung der Stats. 
                 *  Weapons = Name, Wert der Einheit, Gewicht, Dropchance, Schadenmultiplikator
                 * 
                 */
                Weapon bat = new Weapon("Knüppel", 10, 1, 25, dice.DiceTrow(3));
                allWeapon.Add(bat);
                Weapon knuckleduster = new Weapon("Schlagring", 10, 1, 25, dice.DiceTrow(5));
                allWeapon.Add(knuckleduster);

                /*
                 * Erstellen der ersten NPC
                 * 
                 * Erstmal 6 Stück = 2 Für jedes Vault.
                 * Einer der Sachen verkauft und Quest vergibt 
                 * Und ein Arzt um gegen Geld heilen oder Rad heilen zu lassen
                 */
                //Ärzte
                roomA[1].NPC.Add(doc = new NPC("Doktor", dice.DiceTrow(6), dice.DiceTrow(6), dice.DiceTrow(6)));
                roomA[1].HasSomeToFight = true;
                roomA[3].NPC.Add(doc = new NPC("Doktor", dice.DiceTrow(6), dice.DiceTrow(6), dice.DiceTrow(6)));
                roomA[3].HasSomeToFight = true;
                roomA[7].NPC.Add(doc = new NPC("Doktor", dice.DiceTrow(6), dice.DiceTrow(6), dice.DiceTrow(6)));
                roomA[7].HasSomeToFight = true;
                //Questgeber
                roomB[1].NPC.Add(follower = new NPC("Bewohner", dice.DiceTrow(6), dice.DiceTrow(6), dice.DiceTrow(6)));
                roomB[1].HasSomeToFight = true;
                roomB[3].NPC.Add(follower = new NPC("Bewohner", dice.DiceTrow(6), dice.DiceTrow(6), dice.DiceTrow(6)));
                roomB[3].HasSomeToFight = true;
                roomB[7].NPC.Add(follower = new NPC("Bewohner", dice.DiceTrow(6), dice.DiceTrow(6), dice.DiceTrow(6)));
                roomB[7].HasSomeToFight = true;
                FillRooms();
            }
        }
        /*
         * Wenn der Spieler das Vault betritt, wird diese Methode ausgeführt und das Commonwealth
         * wird wieder neu befüllt. Alle Items und Gegner raus und neue rein. Ausserdem muss der Spieler
         * nun wieder alle Räume neu angucken. 
         */
        public void ClearRooms()
        {
            if (this.player.CurrentRoom.Place == "Vault")
            {
                Room[][] allRoom = { roomA, roomB, roomC, roomD, roomE, roomF, roomG };
                for (int i = 2; i < 7; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        allRoom[i][j].Things.RemoveRange(0, allRoom[i][j].Things.Count); 
                        allRoom[i][j].Monster.RemoveRange(0, allRoom[i][j].Monster.Count);
                        allRoom[i][j].Container.RemoveRange(0, allRoom[i][j].Container.Count);
                        allRoom[i][j].IsChecked = false;
                        allRoom[i][j].HasSomeToFight = false;
                        allRoom[i][j].HasStuff = false;
                    }
                }
                FillRooms();
            }
        }
        /*
         * Die Räume werden mir allen Spiel elementen gefüllt: Items, Behälter, Monster 
         */
        public void FillRooms()
        {
            /* 
             * Alle Raumelemente in eine weiteres Array zum angreifen 
             */
            Room[][] allRoom = { roomA, roomB, roomC, roomD, roomE, roomF, roomG };
            Tools code = new Tools("Zugangscode", 50, 10, 1, 1);
            /* 
                 * Jeder Raum bekommt einen Beutel, Kiste oder Truhe.
                 * Wenn eines von diesen im Raum vorkommt, wird diese gleich mit zufälligen 
                 * Gegenständen befüllt.
                 * 
                 * Die Schleife durchzählt nur das Commonwealth
                 *  C - G und 1 - 10
                 */


            //////// Testing 
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            roomB[5].HasStuff = true;
            roomB[5].Things.Add(allPotions[0]);
            roomB[5].Things.Add(allCrap[0]);


            //////// Testing 
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            for (int i = 2; i < 7; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    allRoom[i][j].IsChecked = false;
                    /*
                     * Alle Räume werden durchgezählt. Für jeden Raum wird gewürfelt ob dieser Raum einen Container hat.
                     * Würfel (W100) < 60:
                     *                      Beutel
                     * Würfel (W100) < 35:
                     *                      Kiste
                     * Würfel (W100) < 15:
                     *                      Truhe (verschlossen nur mit Haarklammer zu öffnen)
                     * 
                     * Anschliessend wird gewürfelt welches Item in diesen Container kommt. 
                     * Dazu wird die Liste des zugehörigen Item gezählt und als Augenzahl
                     * für den Würfel benutzt.
                     * 
                     * Kronkorken werden neu erstellt für jeden Raum, ebenso Harrklammern.
                     * 
                     * Der Zugangscode kann (wenn gefunden) für das zweite Vault benutzt werden, 
                     * diesen bekommt man aber auch wenn man weiter die Quest macht.
                     * 
                     * Beutel Inhalt:
                     * 1. Crap      2x Crap Item                         
                     * 2. Tools     Kronkorken (Anzahl wird durch den Value erwürfelt * 10)
                     * 
                     * Kiste Inhalt:
                     * 1. Crap      2x Crap 
                     * 2. Tools     Kronkorken (Anzahl wird durch den Value erwürfelt * 20)
                     * 3. Tools     Lockpicks 
                     * 4. Potions   Ein Verbrauchsitem 
                     * * 
                     * Truhe Inhalt:
                     * 1. Tools     Zugangscode
                     * 2. Tools     Kronkorken (Anzahl wird durch den Value erwürfelt *40)
                     * 3. Tools     Lockpicks 
                     * 4. Potions   2x Verbrauchsitem 
                     * 5. Weapons   Waffe (mit Dropchancenwurf) 
                     */
                    if (dice.DiceTrow(100) < 60)
                    {
                        Container bag = new Container("Beutel", false, 1);
                        allRoom[i][j].Container.Add(bag);
                        bag.HaveStuff.Add(allCrap[dice.DiceTrow(allCrap.Count() - 1)]);
                        bag.HaveStuff.Add(allCrap[dice.DiceTrow(allCrap.Count() - 1)]);
                        bag.HaveStuff.Add(bottlecaps = new Tools("Kronkorken", 1, 100, dice.DiceTrow(10), 2));
                        if (dice.DiceTrow(100) < 45)
                        {
                            bag.HaveStuff.Add(bobbypin = new Tools("Haarklammer", 1, 45, dice.DiceTrow(3), 3));
                        }
                    }
                    if (dice.DiceTrow(100) < 35)
                    {
                        Container box = new Container("Kiste", false, 2);
                        allRoom[i][j].Container.Add(box);
                        box.HaveStuff.Add(allCrap[dice.DiceTrow(allCrap.Count() - 1)]);
                        box.HaveStuff.Add(allCrap[dice.DiceTrow(allCrap.Count() - 1)]);
                        box.HaveStuff.Add(bottlecaps = new Tools("Kronkorken", 1, 100, dice.DiceTrow(20), 2));
                        box.HaveStuff.Add(bobbypin = new Tools("Haarklammer", 1, 45, dice.DiceTrow(3), 3));
                        box.HaveStuff.Add(allPotions[dice.DiceTrow(allPotions.Count() - 1)]);
                    }
                    if (dice.DiceTrow(100) < 15)
                    {
                        Container chest = new Container("Truhe", true, 3);
                        allRoom[i][j].Container.Add(chest);
                        if (dice.DiceTrow(100) < code.DropChance)
                        {
                            chest.HaveStuff.Add(code);
                        }
                        chest.HaveStuff.Add(bottlecaps = new Tools("Kronkorken", 1, 100, dice.DiceTrow(40), 2));
                        chest.HaveStuff.Add(bobbypin = new Tools("Haarklammer", 1, 45, dice.DiceTrow(3), 3));
                        chest.HaveStuff.Add(allPotions[dice.DiceTrow(allPotions.Count() - 1)]);
                        chest.HaveStuff.Add(allPotions[dice.DiceTrow(allPotions.Count() - 1)]);
                        chest.HaveStuff.Add(allWeapon[dice.DiceTrow(allWeapon.Count() - 1)]);
                    }
                    /*
                     * Neben den Container, die man öffnen kann. Sollen natürlich auch noch paar Items rumfliegen.
                     * Es herrscht eine Apokalypse da muss auch keine Ordnung in Räumen sein.
                     * 
                     * Geld (Kronkorken) können zu kleinen Teilen auch herum fliegen 
                     * 
                     */
                    for (int k = 1; k < dice.DiceTrow(4); k++)
                    {
                        allRoom[i][j].HasStuff = true;
                        allRoom[i][j].Things.Add(allCrap[dice.DiceTrow(allCrap.Count() - 1)]);

                    }
                    if (dice.DiceTrow(100) < 50)
                    {
                        allRoom[i][j].Things.Add(bottlecaps = new Tools("Kronkorken", 1, 100, dice.DiceTrow(10), 2));
                    }
                    /*
                     * Ausloten ob dieser Raum ein Monster hat 
                     * 4 Arten von Monster erstmal. Wurf gibt an welches Monster es gibt.
                     * Wurf unter 1 - 25 = Ghul (sehr schwer)
                     * Wurf unter 26 - 50 = Skorpion ( schwere gegner)
                     * Wurf unter 51 - 75 =  Käfer ( normale)
                     * Wurf unter 76 - 100 =  Ratte (einfach)
                     * 
                     * Monster wird erstellt mit folgenen Werten:
                     *  
                     *  Name = String
                     *  
                     *  Einfache Gegner 
                     *      Stärke = Würfel W6
                     *      RewardGold = W3
                     *      XPMultiplikator = 1    
                     *  Normale Gegner
                     *      Stärke = Würfel W6 + 4      
                     *      RewardGold = W4
                     *      XPMultiplikator = 2    
                     *  Schwere Gegner
                     *      Stärke = Würfel W6 + 8
                     *      RewardGold = W8
                     *      XPMultiplikator = 3  
                     *  Sehr schwere Gegner
                     *      Stärke = Würfel W6 + 10
                     *      RewardGold = W10
                     *      XPMultiplikator = 4    
                     *  
                     *  RewardGold
                     */
                    Monster rat;
                    Monster bug;
                    Monster scorpion;
                    Monster ghul;
                    if (dice.DiceTrow(100) < 50)  // 50
                    {
                        int whichMonster = dice.DiceTrow(100);
                        if (whichMonster <= 25) // 25
                        {
                            allRoom[i][j].Monster.Add(rat = new Monster("Ratte", dice.DiceTrow(6), dice.DiceTrow(6), dice.DiceTrow(30), 1));
                            allRoom[i][j].HasSomeToFight = true;
                        }
                        else if (whichMonster <= 50)
                        {
                            allRoom[i][j].Monster.Add(bug = new Monster("Käfer", dice.DiceTrow(6) + 4, dice.DiceTrow(6), dice.DiceTrow(40), 2));
                            allRoom[i][j].HasSomeToFight = true;
                        }
                        else if (whichMonster <= 75)
                        {
                            allRoom[i][j].Monster.Add(scorpion = new Monster("Skorpion", dice.DiceTrow(6) + 8, dice.DiceTrow(6), dice.DiceTrow(80), 3));
                            allRoom[i][j].HasSomeToFight = true;
                        }
                        else if (whichMonster <= 100)
                        {
                            allRoom[i][j].Monster.Add(ghul = new Monster("Ghul", dice.DiceTrow(6) + 10, dice.DiceTrow(6), dice.DiceTrow(100), 4));
                            allRoom[i][j].HasSomeToFight = true;
                        }
                    }
                }
            }
        }
        /*
         * Den Räumen eine Beschreibung mit auf dem Weg geben 
         */
        public void MakeDescription()
        {
            roomB[5].Description = "Dein Zimmer";
            roomB[3].Description = "Marktplatz";
            roomB[0].Description = "Marktplatz";
            roomB[7].Description = "Marktplatz";
            roomA[3].Description = "Arztzimmer";
            roomA[1].Description = "Arztzimmer";
            roomA[7].Description = "Arztzimmer";
            roomB[2].Description = "Raum mit Treppe";
            roomB[6].Description = "Raum mit Treppe";
            roomB[10].Description = "Raum mit Treppe";
            roomG[1].Description = "Lukeneingang zum Vault 2";
            roomC[5].Description = "Lukeneingang zum Vault 1";
            roomF[9].Description = "Lukeneingang zum Vault 3";
        }

    }
}

