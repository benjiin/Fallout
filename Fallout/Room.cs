using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Room
    {
        public Room(string name)
        {
            this.Name = name;
            this.PathUp = PathUp;
            this.PathDown = PathDown;
            this.PathNorth = PathNorth;
            this.PathEast = PathEast;
            this.PathSouth = PathSouth;
            this.PathWest = PathWest;
        }
        //private string Name { get; set; }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Room pathDown;

        public Room PathDown
        {
            get { return pathDown; }
            set { pathDown = value; }
        }

        private Room pathUp;

        public Room PathUp
        {
            get { return pathUp; }
            set { pathUp = value; }
        }

        private Room pathNorth;

        public Room PathNorth
        {
            get { return pathNorth; }
            set { pathNorth = value; }
        }

        private Room pathEast;

        public Room PathEast
        {
            get { return pathEast; }
            set { pathEast = value; }
        }

        private Room pathSouth;

        public Room PathSouth
        {
            get { return pathSouth; }
            set { pathSouth = value; }
        }

        private Room pathWest;

        public Room PathWest
        {
            get { return pathWest; }
            set { pathWest = value; }
        }










    }
}
