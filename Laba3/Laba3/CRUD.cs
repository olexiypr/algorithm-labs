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
        public const string Path = "database.txt";
        public const int CountRecordsInBlock = 50;
        public static List<Block> Blocks;
        public static Record Add(string value)
        {
            var blocks = GetBlocks();
            var lastBlock = blocks.Last();
            if (lastBlock.Records.Count == CountRecordsInBlock)
            {
                var rec = new Record
                {
                    Key = lastBlock.Records.Last().Key + 1,
                    Value = value
                };
                blocks.Add(new Block
                {
                    FirstIndex = lastBlock.Records.Last().Key + 1,
                    Records = new List<Record>()
                    {
                        rec
                    }
                });
                WriteBlocks();
                return rec;
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

        private static Block GetBlockByKey(int key)
        {
            GetBlocks();
            if (Blocks.Count == 1)
            {
                return Blocks[0];
            }

            key = GetStartIndex(key);
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
                    return Blocks[mid];  
                }  
                else if (key < Blocks[mid].FirstIndex)  
                {  
                    max = mid - 1;  
                }  
                else  
                {  
                    min = mid + 1;  
                }  
            }
            throw new IndexOutOfRangeException();
        }

        private static int GetStartIndex(int key)
        {
            while (key % 50 != 0)
            {
                key--;
            }

            return key;
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
        private static Record GetRecordInBlockByKey(int key, Block block)
        {
            var min = 0;
            var max = block.Records.Count - 1; 
            while (min <=max)  
            {  
                var mid = (min + max) / 2;  
                if (key == block.Records[mid].Key)  
                {  
                    return block.Records[mid];  
                }  
                else if (key < block.Records[mid].Key)  
                {  
                    max = mid - 1;  
                }  
                else  
                {  
                    min = mid + 1;  
                }  
            }  
            throw new IndexOutOfRangeException();
        }
        private static Block GetBlockByFirstIndex(int index)
        {
            var formatter = new BinaryFormatter();
            using var fs = new FileStream(Path, FileMode.Open);
            Block currentBlock;
            while ((currentBlock = formatter.Deserialize(fs) as Block) != null)
            {
                if (currentBlock.FirstIndex == index)
                {
                    return currentBlock;
                }
            }
            throw new IndexOutOfRangeException();
        }
        private static Record GetLastRecord(Block block = null)
        {
            if (block == null)
            {
                return new Record
                {
                    Key = 0,
                    Value = string.Empty
                };
            }

            return block.Records.Last();
        }

        private static List<Block> GetBlocks()
        {
            var formatter = new BinaryFormatter();
            using var fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
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
            using var fs = new FileStream(Path, FileMode.Truncate, FileAccess.Write, FileShare.None);
            formatter.Serialize(fs, Blocks);
            fs.Flush();
        }
    }
}
