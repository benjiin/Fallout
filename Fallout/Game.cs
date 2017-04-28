using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Game
    {
        private Room room;

        public void Init()
        {
            // Vault Bunker 2
            for(int i=1; i>7; i++)
            {
                for(int j=1; j>11; j++)
                {
                    string rname = i.ToString() + j.ToString();
                    Room room = new Room();
                    this.room.Name = rname;
                }
                Console.WriteLine(room.Name);
                Console.ReadKey();
            }
            

        }
    }   
}
