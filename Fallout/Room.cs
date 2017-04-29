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
        public Room PathNorth { get; set; } = null;
        public Room PathEast { get; set; } = null;
        public Room PathSouth { get; set; } = null;
        public Room PathWest { get; set; } = null;
        public Room PathUp { get; set; } = null;
        public Room PathDown { get; set; } = null;

        public Room()
        {
            this.Name = Name;
            this.PathDown = PathDown;
            this.PathEast = PathEast;
            this.PathNorth = PathNorth;
            this.PathSouth = PathSouth;
            this.PathWest = PathWest;
            this.PathUp = PathUp;
        }
    }
}
