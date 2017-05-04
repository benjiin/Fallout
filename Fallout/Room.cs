using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Room 
    {
        private List<Stuff> things = new List<Stuff>();

        public List<Stuff> Things
        {
            get { return things; }
            set { things = value; }
        }

        private List<Container> container = new List<Container>();

        public List<Container> Container
        {
            get { return container; }
            set { container = value; }
        }


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

        public bool IsContaminated { get; set; }

        public Room(string name, bool contamineated)
        {
            this.Name = name;
            this.PathUp = PathUp;
            this.PathDown = PathDown;
            this.PathNorth = PathNorth;
            this.PathEast = PathEast;
            this.PathSouth = PathSouth;
            this.PathWest = PathWest;
            this.things = Things;
            this.Container = Container;
            this.IsContaminated = contamineated;
        }

        public void GetStuff()
        {
            foreach (var item in things)
            {
                Console.WriteLine(item.Name);
            }
        }









    }
}
