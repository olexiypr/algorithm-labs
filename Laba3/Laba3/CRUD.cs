using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_UI
{
    public static class CRUD
    {
        public const string FileName = "database.txt";
        public const int CountRecordsInBlock = 50;
        public static int CountEquals = 0;
        public static List<Block> Blocks;
        public static Record Add(string value)
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

        public static Record GetByKey(int key)
        {
            var blocks = GetBlocks();
            if (blocks.Count == 1)
            {
                return GetRecordInBlockByKey(key, blocks[0]);
            }

            var block = GetBlockByKey(key);
            return GetRecordInBlockByKey(key, block);
        }

        public static Block GetBlockByKey(int key)
        {
            GetBlocks();
            if (Blocks.Count == 1)
            {
                return Blocks[0];
            }

            key -= key % 50;
            if (key == 0)
            {
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
        public static void DeleteRecordByKey(int key)
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
        public static Record GetRecordInBlockByKey(int key, Block block)
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
        public static List<Block> GetBlocks()
        {
            var formatter = new BinaryFormatter();
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            if (fs.Length == 0)
            {
                var b = new List<Block>()
                {
                    new Block
                    {
                        FirstIndex = 1,
                        Records = new List<Record>()
                        {
                            new Record
                            {
                                Key = 0,
                                Value = String.Empty
                            }
                        }
                    }
                };
                Blocks = b;
                return b;
            }
            var blocks = new List<Block>(formatter.Deserialize(fs) as List<Block> ?? new List<Block>());
            fs.Flush();
            Blocks = blocks;
            return blocks;
        }
        public static void WriteBlocks()
        {
            var formatter = new BinaryFormatter();
            using var fs = new FileStream(FileName, FileMode.Truncate, FileAccess.Write, FileShare.None);
            formatter.Serialize(fs, Blocks);
            fs.Flush();
        }
    }
}
