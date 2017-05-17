using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    abstract class Quest 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public bool TaskToDo { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
        public Stuff RewardItem { get; set; }
        public int RewardXP { get; set; }
        public int RewardGold { get; set; }
        public Room CurrentRoom { get; set; }
        public LivingCreature Enemy { get; set; }
        public Stuff FindThisItem { get; set; }
        public string Hint { get; set; }


        public void Complete()
        {

        }
    }

}