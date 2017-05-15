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
            this.NeedExperience = this.Level * 100;
            this.XrayRadiation = 0;
            this.MaxXrayRadiation = 100;
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
        public void GetStats()
        {
            if (this.Name.Length >= 9)
            {
                Console.Write(this.Name.Substring(0, 9) + "...");
            }
            else
            {
                Console.Write(this.Name);
            }
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
    }
}
