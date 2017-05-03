using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Container : Stuff
    {
        public bool Locked { get; set; }
        public List<Potions> HavePotions{ get; set; } 
        public List<Crap> HaveCrap { get; set; }
        public List<Weapon> HaveWeapon { get; set; }

        public Container()
        {
            HavePotions = new List<Potions>();
            HaveCrap = new List<Crap>();
            HaveWeapon = new List<Weapon>();
            this.Name = Name;
            this.Locked = Locked;
            this.HavePotions = HavePotions;
            this.HaveCrap = HaveCrap;
            this.HaveWeapon = HaveWeapon;
        }

        public void GetPotions()
        {
            foreach (var item in HavePotions)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void GetCrap()
        {
            foreach (var item in HaveCrap)
            {
                Console.WriteLine(item.Name);
            }
        }

    }
}
