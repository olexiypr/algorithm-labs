using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_UI
{
    public class CRUD : ICrud
    {
        public static ICrud GetCRUD()
        {
            return _crud ??= new CRUD();
        }

        private static ICrud _crud;
        private const string FileName = "database.txt";
        private const int CountRecordsInBlock = 50;
        public int CountEquals = 0;
        public List<Block> Blocks { get; set; }
        public Record Add(string value)
        {
            var blocks = GetBlocks();
            var lastBlock = blocks.Last();
            if (lastBlock.Records.Count == CountRecordsInBlock)
            {
                var newRecord = new Record
                {
                    Key = lastBlock.Records.Last().Key + 1,
                    Value = value
                };
                blocks.Add(new Block
                {
                    FirstIndex = lastBlock.Records.Last().Key + 1,
                    Records = new List<Record> {newRecord}
                });
                WriteBlocks();
                return newRecord;
            }
            var lastRecord = lastBlock.Records.Last();
            var record = new Record
            {
                Key = lastRecord.Key + 1,
                Value = value
            };
            blocks.Last().Records.Add(record);
            WriteBlocks();
            return record;
        }

        public (int, Record) GetByKey(int key)
        {
            var blocks = GetBlocks();
            if (blocks.Count == 1)
            {
                return (CountEquals, GetRecordInBlockByKey(key, blocks[0]));
            }

            var block = GetBlockByKey(key);
            var record = GetRecordInBlockByKey(key, block);
            var countEquals = CountEquals;
            var result = (countEquals,record);
            CountEquals = 0;
            return result;
        }
        
        private Block GetBlockByKey(int key)
        {
            GetBlocks();
            if (Blocks.Count == 1)
            {
                return Blocks[0];
            }

            key -= key % CountRecordsInBlock;
            if (key == 0)
            {
                CountEquals++;
                return Blocks[0];
            }
            var min = 0;
            var max = Blocks.Count - 1; 
            while (min <=max)  
            {  
                var mid = (min + max) / 2;  
                if (key == Blocks[mid].FirstIndex)
                {
                    CountEquals++;
                    return Blocks[mid];  
                }  
                else if (key < Blocks[mid].FirstIndex)
                {
                    CountEquals++;
                    max = mid - 1;  
                }  
                else
                {
                    CountEquals++;
                    min = mid + 1;  
                }  
            }
            throw new IndexOutOfRangeException();
        }
        public void DeleteRecordByKey(int key)
        {
            var block = GetBlockByKey(key);
            var @record = GetRecordInBlockByKey(key, block);
            block.Records.Remove(record);
            if (block.Records.Count == 0)
            {
                Blocks.Remove(block);
            }
            WriteBlocks();
        }

        private Record GetRecordInBlockByKey(int key, Block block)
        {
            var min = 0;
            var max = block.Records.Count - 1; 
            while (min <=max)  
            {  
                var mid = (min + max) / 2;  
                if (key == block.Records[mid].Key)
                {
                    CountEquals++;
                    return block.Records[mid];  
                }  
                else if (key < block.Records[mid].Key)
                {
                    CountEquals++;
                    max = mid - 1;  
                }  
                else
                {
                    CountEquals++;
                    min = mid + 1;  
                }  
            }  
            throw new IndexOutOfRangeException();
        }

        private List<Block> GetBlocks()
        {
            var formatter = new BinaryFormatter();
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            var blocks = new List<Block>(formatter.Deserialize(fs) as List<Block> ?? new List<Block>());
            fs.Flush();
            Blocks = blocks;
            return blocks;
        }
        public void WriteBlocks()
        {
            var formatter = new BinaryFormatter();
            using var fs = new FileStream(FileName, FileMode.Truncate, FileAccess.Write, FileShare.None);
            formatter.Serialize(fs, Blocks);
            fs.Flush();
        }
    }
}
