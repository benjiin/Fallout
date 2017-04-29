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
        Room[] roomA = new Room[11];
        Room[] roomB = new Room[11];
        Room[] roomC = new Room[11];
        Room[] roomD = new Room[11];
        Room[] roomE = new Room[11];
        Room[] roomF = new Room[11];
        Room[] roomG = new Room[11];
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
            for (int i=0; i<=10; i++)
            {
                roomA[i] = new Room("A" + (i));
                roomB[i] = new Room("B" + (i));
                roomC[i] = new Room("C" + (i));
                roomD[i] = new Room("D" + (i));
                roomE[i] = new Room("E" + (i));
                roomF[i] = new Room("F" + (i));
                roomG[i] = new Room("G" + (i));
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

            roomA[6].PathNorth = roomB[6];
            roomA[6].PathWest = roomB[5];

            roomB[3].PathEast = roomB[4];
            roomB[3].PathSouth = roomA[3];

            roomB[4].PathSouth = roomB[4];
            roomB[4].PathWest = roomB[3];

            roomB[5].PathSouth = roomA[5];

            roomB[6].PathSouth = roomA[6];
            roomB[5].PathUp = roomC[5];
            // Vault 3
            roomA[7].PathNorth = roomB[7];
            roomA[7].PathEast = roomA[8];

            roomA[8].PathNorth = roomB[8];
            roomA[8].PathEast = roomA[9];
            roomA[8].PathWest = roomA[7];

            roomA[9].PathEast = roomA[10];
            roomA[9].PathWest = roomA[8];

            roomA[10].PathNorth = roomB[10];
            roomA[10].PathWest = roomA[9];
      
            roomB[7].PathEast = roomB[8];
            roomB[7].PathSouth = roomA[7];

            roomB[8].PathEast = roomB[9];
            roomB[8].PathSouth = roomA[8];
            roomB[8].PathWest = roomB[7];

            roomB[9].PathWest = roomB[8];

            roomB[10].PathSouth = roomA[10];
            roomB[10].PathUp = roomF[9];
            // Commonwealth 
            roomC[0].PathNorth = roomD[0];
            roomC[0].PathEast = roomC[1];

            roomC[1].PathNorth = roomD[1];
            roomC[1].PathWest = roomD[0];

            roomC[2].PathNorth = roomD[2];
            roomC[2].PathEast = roomC[3];

            roomC[3].PathNorth = roomD[3];
            roomC[3].PathEast = roomC[4];
            roomC[3].PathWest = roomC[2];

            roomC[4].PathNorth = roomD[4];
            roomC[4].PathEast = roomD[5];
            roomC[4].PathWest = roomD[3];

            roomC[5].PathEast = roomC[6];
            roomC[5].PathWest = roomC[4];

            roomC[6].PathEast = roomD[7];
            roomC[6].PathWest = roomC[5];

            













        }







    }   
}

