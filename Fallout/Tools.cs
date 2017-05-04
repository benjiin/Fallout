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
        public Tools(string name, int value, int dropchance, int amount)
        {
            this.Name = name;
            this.Value = value;
            this.DropChance = dropchance;
            this.Amount = amount;
            AllTools.Add(this);
        }

        public int GetAllTools()
        {
            return AllTools.Count();
        }

        public Tools GetSpecificItem(int index)
        {
            return AllTools.ElementAt(index - 1);
        }
    }
}
