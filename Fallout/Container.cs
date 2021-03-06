﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    [Serializable()]
    class Container : Stuff
    {
        public bool Locked { get; set; }
        public List<Stuff> HaveStuff { get; set; } = new List<Stuff>();
        public Container(string name, bool locked, int id)
        {
            this.Name = name;
            this.Locked = locked;
            this.HaveStuff = HaveStuff;
            this.ID = id;
        }
        /*
         * Zeige mir die Items in diesem Behälter an, ist das Item ID ==2 (Kronkorken) dann zeige mir die Menge an
         * z.B.
         * Kronkorken (23) 
         * Sieht schöner aus 
         */ 
        public void GetStuff()
        {
            foreach (var item in HaveStuff)
            {
                if(item.Amount >2)
                {
                    Console.WriteLine(item.Name + " (" + item.Amount + ")");
                }
                else
                {
                    Console.WriteLine(item.Name);
                }
            }
        } 
        /*
         * Einfache Methode zum entfernen des jeweiligen Items in einem Behälter
         */ 
        public void RemoveCrap(int index)
        {
            this.HaveStuff.RemoveAt(index);
        }  
    }
}
