﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Player : LivingCreature
    {
        Dice dice = new Dice();
        public List<Quest> QuestLog { get; set; }
        public int Experience { get; set; }

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
            this.CurrentRoom = this.CurrentRoom;
            this.Level = 1;
            this.Experience = this.Level * 100;
            this.XrayRadiation = 0;
        }


        public void AddInventar(Stuff item)
        {
            if(item is Tools)
            {
                if(item.ID ==2)
                {
                    this.Money += item.Amount;
                }
            }
            else
            {
                if(!(this.CarryWeight > this.CarryWeightMax))
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

        public void GetallInventar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in this.Inventory)
            {
                Console.WriteLine("\t" + item.Name);
            }
            Console.ResetColor();
        }



    }
}
