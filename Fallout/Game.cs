﻿using System;
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
            for (int i = 0; i <= 10; i++)
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
            roomA[3].PathEast = roomA[4];

            roomA[4].PathNorth = roomB[4];
            roomA[4].PathEast = roomA[5];
            roomA[4].PathWest = roomA[3];

            roomA[5].PathNorth = roomB[5];
            roomA[5].PathEast = roomA[6];
            roomA[5].PathWest = roomA[4];

            roomA[6].PathNorth = roomB[6];
            roomA[6].PathWest = roomA[5];

            roomB[3].PathEast = roomB[4];
            roomB[3].PathSouth = roomA[3];

            roomB[4].PathSouth = roomA[4];
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
            roomC[1].PathWest = roomC[0];

            roomC[2].PathNorth = roomD[2];
            roomC[2].PathEast = roomC[3];

            roomC[3].PathNorth = roomD[3];
            roomC[3].PathEast = roomC[4];
            roomC[3].PathWest = roomC[2];

            roomC[4].PathNorth = roomD[4];
            roomC[4].PathEast = roomC[5];
            roomC[4].PathWest = roomC[3];

            roomC[5].PathEast = roomC[6];
            roomC[5].PathWest = roomC[4];

            roomC[6].PathEast = roomC[7];
            roomC[6].PathWest = roomC[5];

            roomC[7].PathEast = roomC[8];
            roomC[7].PathWest = roomC[6];

            roomC[8].PathEast = roomC[9];
            roomC[8].PathWest = roomC[7];

            roomC[9].PathNorth = roomD[8];
            roomC[9].PathEast = roomC[9];
            roomC[9].PathWest = roomC[7];

            roomC[10].PathNorth = roomD[10];
            roomC[10].PathWest = roomC[9];

            roomD[0].PathNorth = roomE[0];
            roomD[0].PathEast = roomD[1];
            roomD[0].PathSouth = roomC[0];

            roomD[1].PathNorth = roomE[1];
            roomD[1].PathWest = roomD[0];
            roomD[1].PathSouth = roomC[1];

            roomD[2].PathNorth = roomE[2];
            roomD[2].PathSouth = roomC[2];

            roomD[3].PathNorth = roomE[3];
            roomD[3].PathSouth = roomC[3];

            roomD[4].PathNorth = roomE[4];
            roomD[4].PathSouth = roomC[4];

            roomD[5].PathNorth = roomE[5];
            roomD[5].PathEast = roomD[6];

            roomD[6].PathEast = roomD[7];
            roomD[6].PathWest = roomD[5];

            roomD[7].PathEast = roomD[8];
            roomD[7].PathWest = roomD[6];

            roomD[8].PathEast = roomD[9];
            roomD[8].PathWest = roomD[7];

            roomD[9].PathNorth = roomE[9];
            roomD[9].PathWest = roomD[8];
            roomD[9].PathSouth = roomC[9];

            roomD[10].PathNorth = roomE[10];
            roomD[10].PathSouth = roomC[10];

            roomE[0].PathNorth = roomF[0];
            roomE[0].PathEast = roomE[1];
            roomE[0].PathSouth = roomD[0];

            roomE[1].PathEast = roomE[2];
            roomE[1].PathSouth = roomD[1];
            roomE[1].PathWest = roomE[0];

            roomE[2].PathNorth = roomF[2];
            roomE[2].PathEast = roomE[3];
            roomE[2].PathSouth = roomD[2];
            roomE[2].PathWest = roomE[1];

            roomE[3].PathEast = roomE[4];
            roomE[3].PathSouth = roomD[3];
            roomE[3].PathWest = roomE[2];

            roomE[4].PathEast = roomE[5];
            roomE[4].PathSouth = roomD[4];
            roomE[4].PathWest = roomE[3];

            roomE[5].PathEast = roomE[6];
            roomE[5].PathSouth = roomD[5];
            roomE[5].PathWest = roomE[4];

            roomE[6].PathNorth = roomF[6];
            roomE[6].PathEast = roomE[7];
            roomE[6].PathWest = roomE[5];

            roomE[7].PathNorth = roomF[7];
            roomE[7].PathEast = roomE[8];
            roomE[7].PathWest = roomE[6];

            roomE[8].PathEast = roomE[9];
            roomE[8].PathWest = roomE[7];

            roomE[9].PathEast = roomE[10];
            roomE[9].PathSouth = roomD[9];
            roomE[9].PathWest = roomE[8];

            roomE[10].PathNorth = roomF[10];
            roomE[10].PathWest = roomE[9];
            roomE[10].PathSouth = roomD[10];

            roomF[0].PathNorth = roomG[0];
            roomF[0].PathEast = roomF[1];
            roomF[0].PathSouth = roomE[1];

            roomF[1].PathEast = roomF[2];
            roomF[1].PathWest = roomF[0];

            roomF[2].PathNorth = roomG[2];
            roomF[2].PathEast = roomF[3];
            roomF[2].PathSouth = roomE[2];
            roomF[2].PathWest = roomF[1];

            roomF[3].PathNorth = roomG[3];
            roomF[3].PathEast = roomF[4];
            roomF[3].PathWest = roomF[2];

            roomF[4].PathNorth = roomG[4];
            roomF[4].PathWest = roomF[3];

            roomF[5].PathNorth = roomG[5];
            roomF[5].PathEast = roomF[6];

            roomF[6].PathEast = roomF[7];
            roomF[6].PathSouth = roomE[6];
            roomF[6].PathWest = roomF[5];

            roomF[7].PathNorth = roomG[7];
            roomF[7].PathEast = roomF[8];
            roomF[7].PathSouth = roomE[7];
            roomF[7].PathWest = roomF[6];

            roomF[8].PathEast = roomF[9];
            roomF[8].PathWest = roomF[7];

            roomF[9].PathEast = roomF[10];
            roomF[9].PathWest = roomF[8];

            roomF[10].PathNorth = roomG[10];
            roomF[10].PathWest = roomF[9];
            roomF[10].PathSouth = roomE[10];

            roomG[0].PathEast = roomG[1];
            roomG[0].PathSouth = roomF[0];

            roomG[1].PathEast = roomG[2];
            roomG[1].PathWest = roomG[0];

            roomG[2].PathEast = roomG[3];
            roomG[2].PathSouth = roomF[2];
            roomG[2].PathWest = roomG[1];

            roomG[3].PathEast = roomG[4];
            roomG[3].PathSouth = roomF[3];
            roomG[3].PathWest = roomG[2];

            roomG[4].PathEast = roomG[5];
            roomG[4].PathSouth = roomF[4];
            roomG[4].PathWest = roomG[3];

            roomG[5].PathEast = roomG[6];
            roomG[5].PathSouth = roomF[5];
            roomG[5].PathWest = roomG[4];

            roomG[6].PathEast = roomG[7];
            roomG[6].PathWest = roomG[5];

            roomG[7].PathEast = roomG[8];
            roomG[7].PathSouth = roomF[7];
            roomG[7].PathWest = roomG[6];

            roomG[8].PathEast = roomG[9];
            roomG[8].PathWest = roomG[7];

            roomG[9].PathEast = roomG[10];
            roomG[9].PathWest = roomG[8];

            roomG[10].PathSouth = roomF[10];
            roomG[10].PathWest = roomG[9];







        }







    }   
}

