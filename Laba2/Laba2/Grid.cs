using System;
using System.Diagnostics;

namespace Laba2
{
    public class Grid
    {
        public Cell[,] Map { get; set; }

        public Cell this[int x, int y]
        {
            get => Map[x, y];
            set => Map[x, y] = value;
        }

        public Grid()
        {
            Map = new Cell[8, 8];
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Map[i, j] = new Cell(i,j);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    var str = Map[i, j].IsEmpty ? "." : "_";
                    Console.Write(str + " ");
                }

                Console.WriteLine();
            }
        }
    }
}