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
        private Room PathNorth { get; set; } = null;
        private Room PathEast { get; set; } = null;
        private Room PathSouth { get; set; } = null;
        private Room PathWest { get; set; } = null;
        private Room PathUp { get; set; } = null;
        private Room PathDown { get; set; } = null;
        
        public string getName()
        {
            return this.Name;
        }


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
