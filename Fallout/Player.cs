using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fallout
{
    class Player : LivingCreature
    {
        Dice dice = new Dice();
        public List<Quest> QuestLog { get; set; }
        
        public int NeedExperience {
            get
            {
                return this.Level * 100;
            }

        }

        public Room Home { get; set; }
        public Player()
        {
            this.Inventory = new List<Stuff>();
            this.QuestLog = new List<Quest>();
            this.Strength = (dice.DiceTrow(6) + dice.DiceTrow(6) + dice.DiceTrow(6)); 
            this.Dexterity = (dice.DiceTrow(6) + dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Constitution = (dice.DiceTrow(6) + dice.DiceTrow(6) + dice.DiceTrow(6));
            this.Dodge = this.Dexterity * 2;
            this.MaxHealthPoints = ((this.Strength + this.Constitution) / 2);
            this.HealthPoints = this.MaxHealthPoints;
            this.CarryWeightMax = ((this.Strength + 5) * 2);
            this.CarryWeight = 0;            
            this.Level = 1;
            this.Experience = 0;
            this.XrayRadiation = 0;
            this.MaxXrayRadiation = 100;
            this.Money = 0;
        }


        public void AddInventar(Stuff item)
        {
            if(item is Tools)
            {
                if(item.ID == 2)
                {
                    this.Money += item.Amount;
                }
                if(item.ID == 3)
                {
                    this.Inventory.Add(item);
                }
            }
            else
            {
                if(this.CarryWeight < this.CarryWeightMax)
                {
                    this.CarryWeight += item.Weight;
                    this.Inventory.Add(item);
                }
                else
                {
                    Console.WriteLine("Zu schwer");
                }
            }            
        }

        public void RemoveInventar(Stuff item)
        {
            if(this.Inventory.Contains(item))
            {
                this.Inventory.Remove(item);
                this.CarryWeight -= item.Weight;
            }
        }


        public  void GetallInventar()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Inventar: ");
            if(this.Inventory.Count == 0)
            {
                Console.WriteLine("Hier scheint nix zu sein");
            }
            else
            {
                foreach (var item in this.Inventory)
                {
                    if (item is Crap)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\t" + item.Name);
                    }
                    if (item is Potions)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t" + item.Name);
                    }
                    if (item is Tools)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\t" + item.Name);
                        if(item.Amount < 1)
                        {
                            item.Name += "(" + item.Amount + ")";
                        }
                    }
                    if (item is Weapon)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t" + item.Name);
                    }
                }     
            }
            Console.ResetColor();
        }
        /*
         * Beste Methode ... Überprüfe mein Inventar ob es bestimmte Items hat
         * 2 == Kronkorken
         * 3 == Tools
         * 4 == Potions 
         */
        public bool HasTools(int id)
        {
            foreach (var item in this.Inventory)
            {
                if(item is Tools)
                {
                    if(item.ID == id)
                    {
                        return true;

                    }
                }
            }
            return false;
        }
        public bool HasCrap()
        {
            foreach (var item in this.Inventory)
            {
                if (item is Crap)
                {
                    return true;
                }

            }
            return false;
        }
        public bool HasPotions()
        {
            foreach (var item in this.Inventory)
            {
                if (item is Potions)
                {
                    return true;
                }

            }
            return false;
        }
        public bool HasWeapons()
        {
            foreach (var item in this.Inventory)
            {
                if (item is Weapon)
                {
                    return true;
                }

            }
            return false;
        }

        public void RemoveItem(Stuff thing)
        {
            //this.
            //for(int i = 0; i < this.Inventory.Count; i++)
            //{
            //    if(this.Inventory[i] is Potions)
            //    {

            //    }
            //}

        }

        public override void GetStats(int start, int end)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(this.Name);
            Console.ResetColor();
            Console.SetCursorPosition(14, start);
            Console.Write("HP: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(this.HealthPoints + "/" + this.MaxHealthPoints);
            Console.ResetColor();
            Console.Write(" STR: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(this.Strength);
            Console.ResetColor();
            Console.Write(" GES: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(this.Dexterity);
            Console.ResetColor();
            Console.Write(" Ausweichen: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(this.Dodge);
            Console.ResetColor();
            Console.Write(" Level: ");
            Console.Write(this.Level);
            Console.Write(" XP: ");
            Console.Write(this.Experience + "/" + this.NeedExperience);
            Console.SetCursorPosition(14, end);
            Console.Write("Gewicht:");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" " + this.CarryWeight + "/" + this.CarryWeightMax);
            Console.ResetColor();
            Console.Write(" Kronkorken: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(this.Money);
            Console.ResetColor();
            Console.Write(" Radiation: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(this.XrayRadiation);
            Console.ResetColor();
        }


        public void RemoveBobby()
        {
            if (this.Inventory != null)
            {
                for (int i = 0; i < this.Inventory.Count; i++)
                {
                    if (this.Inventory[i].ID == 3)
                    {
                        this.Inventory.RemoveAt(i);
                        return;
                    }
                }
            }
        }
        public void CheckQuest()
        {
            foreach (var item in QuestLog)
            {
                
            }
        }
    }
}
