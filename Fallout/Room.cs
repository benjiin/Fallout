using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Room
    {
        public string Name { get; set; }
        public Room PathNorth { get; set; }
        public Room PathEast { get; set; }
        public Room PathSouth { get; set; }
        public Room PathWest { get; set; }
        public Room PathUp { get; set; } = null;
        public Room PathDown { get; set; } = null;

        public Room()
        {
            this.Name = Name;
        }
    }
}
