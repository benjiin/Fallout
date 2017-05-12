using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Tools : Stuff   
    {
        static List<Tools> AllTools = new List<Tools>();
        public Tools(string name, int value, int dropchance, int amount, int id)
        {
            this.Name = name;
            this.Value = value;
            this.DropChance = dropchance;
            this.Amount = amount;
            this.ID = id;
            AllTools.Add(this);
        }


        public Tools GetSpecificItem(int index)
        {
            return AllTools.ElementAt(index - 1);
        }
    }
}
