﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    [Serializable] 
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
        private List<NPC> npc = new List<NPC>();
        public List<NPC> NPC
        {
            get { return npc ; }
            set { npc = value; }
        }

        public int ID { get; set; }
        public bool HasSomeToFight { get; set; } = false;
        public bool HasStuff { get; set; } = false;
        public string Name { get; set; }
        public Room PathDown { get; set; }
        public Room PathUp{ get; set; }
        public Room PathNorth { get; set; }
        public Room PathEast { get; set; }
        public Room PathSouth { get; set; }
        public Room PathWest { get; set; }
        public bool IsContaminated { get; set; }
        public bool IsChecked { get; set; }
        public string Description { get; set; }
        public string Place { get; set; } = "Commonwealth";
        /*
         * Konstruktor 
         */
        public Room(string name, int id)
        {
            this.Name = name;
            this.IsContaminated = false;
            this.ID = id;
        }  
    }
}
