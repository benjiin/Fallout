using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Quest
    {
        public string Name { get; set; }
        public string Descripton { get; set; }
        public string TaskToDo { get; set; }
        public bool IsCompleted { get; set; }
        public Stuff RewardItem { get; set; }
        public int RewardGold { get; set; }
    }

}