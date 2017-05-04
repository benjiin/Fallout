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
        public List<Stuff> HaveStuff { get; set; } = new List<Stuff>();

        public Container(string name, bool locked)
        {
            this.Name = name;
            this.Locked = locked;
            this.HaveStuff = HaveStuff;
        }
        public void GetCrap()
        {
            foreach (var item in HaveStuff)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void RemoveCrap(int index)
        {
            this.HaveStuff.RemoveAt(index);
        }

    }
}
