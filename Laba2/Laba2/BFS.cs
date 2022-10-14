using System;

namespace Laba2
{
    public class BFS
    {
        private Grid Map { get; set; }
        public int iterationCount;
        public int deadEndCount;
        public int statesCount;
        public BFS(Grid map)
        {
            Map = map;
            iterationCount = 0;
            deadEndCount = 0;
            statesCount = 0;
        }
        public bool Start(int strNum)
        {
            iterationCount++;
            if (strNum == 8)
            {
                return true;
            }
            for (int i = 0; i < 8; i++) 
            {
                for (int j = 0; j < 8; j++) 
                {
                    Map[j,strNum].IsEmpty = true;
                }

                statesCount++;
                if (Check(Map[i, strNum]))
                {
                    Map[i, strNum].IsEmpty = false;
                    if (Start(strNum+1)) 
                    {
                        return true;
                    }
                }
            }

            deadEndCount++;
            return false;
        }
        private bool Check(Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;
            if (!cell.IsEmpty)
            {
                return false;
            }
            for (int i = 0; i < y; i++)
            {
                if (!Map[x,i].IsEmpty)
                {
                    return false;
                }
                if (x - 1 - i >= 0 && !Map[x-1-i,y-1-i].IsEmpty) 
                {
                    return false;
                }
                if (x + 1 + i < 8 && !Map[x+1+i, y-1-i].IsEmpty)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsValid()
        {
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!Map[i,j].IsEmpty)
                    {
                        count++;
                        var cell = Map[i, j];
                        int x = cell.X;
                        int y = cell.Y;
                        for (int k = 0; k < y; k++)
                        {
                            if (!Map[x,i].IsEmpty)
                            {
                                return false;
                            }
                            if (x - 1 - k >= 0 && !Map[x-1-k,y-1-k].IsEmpty) 
                            {
                                return false;
                            }
                            if (x + 1 + k < 8 && !Map[x+1+k, y-1-k].IsEmpty)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return count == 8;
        }
    }
}