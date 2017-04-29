using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Game
    {
        /*
         * 7 Reihen Felder & 11 Spalten in Array gepackt  
         */
        Room[] roomA = new Room[10];
        Room[] roomB = new Room[10];
        Room[] roomC = new Room[10];
        Room[] roomD = new Room[10];
        Room[] roomE = new Room[10];
        Room[] roomF = new Room[10];
        Room[] roomG = new Room[10];
        //Room[][] rooms = new Room[7][];


        public Game()
        {
            /*
             * Räume erstellen
             * Reihe A und B werden die "Vaults" (Die Schutzräume unabhängig von dem Commonwealth) und Reihe C-G das Commomwealth
             * Spalte 0 1 2 = Vault 1
             * Spalte 3 4 5 6 = Vault 2
             * Spalte 7 8 9 10 = Vault 3
             */
            for (int i = 0; i < 10; i++)
            {
                roomA[i] = new Room("A" + (i + 1));
                roomB[i] = new Room("B" + (i + 1));
                roomC[i] = new Room("C" + (i + 1));
                roomD[i] = new Room("D" + (i + 1));
                roomE[i] = new Room("E" + (i + 1));
                roomF[i] = new Room("F" + (i + 1));
                roomG[i] = new Room("G" + (i + 1));
            }
            //rooms[0] = new Room[11];
            //rooms[1] = new Room[11];
            //rooms[2] = new Room[11];
            //rooms[3] = new Room[11];
            //rooms[4] = new Room[11];
            //rooms[5] = new Room[11];
            //rooms[6] = new Room[11];

            /*
             * Räume verbinden
             */
            // Vault 1 
            roomA[0].PathNorth = roomB[0];
            roomA[0].PathEast = roomA[1];

            roomA[1].PathNorth = roomB[1];
            roomA[1].PathEast = roomA[2];
            roomA[1].PathWest = roomA[0];

            roomA[2].PathNorth = roomB[2];
            roomA[2].PathWest = roomA[1];

            roomB[0].PathEast = roomB[1];
            roomB[0].PathSouth = roomA[0];

            roomB[1].PathSouth = roomA[1];
            roomB[1].PathWest = roomB[0];

            roomB[2].PathSouth = roomA[2];
            roomB[2].PathUp = roomG[2];
            // Vault 2 
            roomA[3].PathNorth = roomB[3];
            roomA[3].PathEast = roomB[4];

            roomA[4].PathNorth = roomB[4];
            roomA[4].PathEast = roomB[5];
            roomA[4].PathWest = roomB[3];

            roomA[5].PathNorth = roomB[5];
            roomA[5].PathEast = roomB[6];
            roomA[5].PathWest = roomB[4];














        }

        public string getRoomName()
        {
            return this.roomA[0].Name;
        }









    }   
}

