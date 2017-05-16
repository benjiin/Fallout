using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public bool TaskToDo { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
        public Stuff RewardItem { get; set; }
        public int RewardXP { get; set; }
        public int RewardGold { get; set; } 

        public void QuestComplete(int id)
        {
            if(id == 1)
            {
                if (this.TaskToDo == true)
                {
                    this.IsCompleted = true;
                }
            }
        }

    }

}