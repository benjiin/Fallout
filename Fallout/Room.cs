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
        private List<Monster> monster = new List<Monster>();
        public List<Monster> Monster
        {
            get { return monster; }
            set { monster = value; }
        }


        public bool HasMonster { get; set; } = false;

        public string Name { get; set; }
        public Room PathDown { get; set; }
        public Room PathUp{ get; set; }
        public Room PathNorth { get; set; }
        public Room PathEast { get; set; }
        public Room PathSouth { get; set; }
        public Room PathWest { get; set; }
        public bool IsContaminated { get; set; }
        public string Description { get; set; }
        /*
         * Konstruktor 
         */
        public Room(string name)
        {
            this.Name = name;
            this.IsContaminated = false;
        }

        public void GetStuff()
        {
            foreach (var item in things)
                if (item.Amount > 2)
                {
                    Console.WriteLine(item.Name + " (" + item.Amount + ")");
                }
                else
                {
                    Console.WriteLine(item.Name);
                }

            foreach (var item in container)
                if (item.Amount > 2)
                {
                    Console.WriteLine(item.Name + " (" + item.Amount + ")");
                }
                else
                {
                    Console.WriteLine(item.Name);
                }
            foreach (var item in monster)
            {
                Console.WriteLine("MosbterCon: " + item.Constitution + " Monstername: " + item.Name + " Monsterstrength: " + item.Strength +
                    " MonsterXP: " + item.RewardExperiencePoints + " MOnstergold:     " + item.RewardGold +
                    " MonsterHP: " + item.MaxHealthPoints);
            }
        }

    }
}
