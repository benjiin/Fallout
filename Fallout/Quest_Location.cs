using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    [Serializable()]
    class Quest_Location : Quest
    {
        /*
         * Die erste Quest Ihrer Art. Als Location Quest deklariert aber eigentlich als "Finde Person X" ausgegeben" 
         */
        public Quest_Location(Room room, string name)
        {
            this.CurrentRoom = room;
            this.Name = name;
        }       
    }
}
