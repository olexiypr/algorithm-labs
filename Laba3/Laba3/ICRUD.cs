using System.Collections.Generic;

namespace Laba3_UI
{
    public interface ICrud
    {
        public Record Add(string value);
        public (int, Record) GetByKey(int key);
        public void DeleteRecordByKey(int key);
        public void WriteBlocks();
        public List<Block> Blocks { get; set; } 
    }
}