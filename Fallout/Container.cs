using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Container
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public bool Locked { get; set; }
        public List<Potions> HavePotions{ get; set; }
        public List<Crap> HaveCrap { get; set; }
        public List<Weapon> HaveWeapon { get; set; }
    }
}
