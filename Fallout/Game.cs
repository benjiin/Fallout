using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Game
    {
        private Room room = new Room();

        Room roomA1 = new Room();
        Room roomA2 = new Room();
        Room roomA3 = new Room();
        Room roomA4 = new Room();
        Room roomA5 = new Room();
        Room roomA6 = new Room();
        Room roomA7 = new Room();
        Room roomA8 = new Room();
        Room roomA9 = new Room();
        Room roomA10 = new Room();
        Room roomA11 = new Room();
        

        public void Init()
        {
            roomA1.Name = "sds";
        }

 
        public Room getRoom(Room room)
        {
            return this.roomA1;
        }

        public void setRoom(Room room)
        {
            
        }

        
        
        
        
    }   
}

