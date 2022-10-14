using System;
using System.Runtime.InteropServices;

namespace Laba2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var random = new Random();
            for (int i = 0; i < 15; i++)
            {
                var grid = new Grid();
                var startStr = random.Next(0);
                startStr = 3;
                for (int j = 0; j < startStr; j++)
                {
                    grid[random.Next(8), j].IsEmpty = false;
                }
                Console.WriteLine("Input chessboard: ");
                grid.Print();
                var bfs = new BFS(grid);
                var res = bfs.Start(startStr);
                res = bfs.IsValid();
                Console.WriteLine("Success: " + res);
                Console.WriteLine("Result chessboard");
                grid.Print();
                Console.WriteLine("Count iterations: " + bfs.iterationCount);
                Console.WriteLine("Dead ends count: " + bfs.deadEndCount);
                Console.WriteLine("States count: " + bfs.statesCount);
            }
        }
    }
}