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
            for (int i = 0; i < blocks.Count - 1; i++)
            {
                if ((blocks[i].FirstIndex <= key && blocks[i + 1].FirstIndex > key))
                {
                    return GetRecordInBlockByKey(key, blocks[i]); //try catch
                }
                if ((blocks[i].FirstIndex <= key && i == blocks.Count - 2))
                {
                    return GetRecordInBlockByKey(key, blocks[i+1]);
                }
            }

            throw new IndexOutOfRangeException();
        }

        private static Block GetBlockByKey(int key)
        {
            GetBlocks();
            if (Blocks.Count == 1)
            {
                return Blocks[0];
            }
            for (int i = 0; i < Blocks.Count - 1; i++)
            {
                if ((Blocks[i].FirstIndex <= key && Blocks[i + 1].FirstIndex > key))
                {
                    return Blocks[i];
                }
                if ((Blocks[i].FirstIndex <= key && i == Blocks.Count - 2))
                {
                    return Blocks[i + 1];
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
        private static Record GetRecordInBlockByKey(int key, Block block) //need binary search
        {
            var record = block.Records.FirstOrDefault(record => record.Key == key);
            if (record == null)
            {
                throw new IndexOutOfRangeException();
            }

            return record;
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
