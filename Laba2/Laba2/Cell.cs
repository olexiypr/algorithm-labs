namespace Laba2
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsEmpty { get; set; }
        
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            IsEmpty = true;
        }
    }
}