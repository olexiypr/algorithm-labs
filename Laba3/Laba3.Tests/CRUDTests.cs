using System;
using System.Collections.Generic;
using System.IO;
using Laba3_UI;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CRUDTests
    {
        [SetUp]
        public void SetUp()
        {
            using var fs = new FileStream(CRUD.FileName, FileMode.Truncate, FileAccess.Write, FileShare.None);
            fs.Flush();
            fs.Dispose();
            Program.FillDB();
        }
        private readonly Block block = new Block
        {
            FirstIndex = 1,
            Records = new List<Record>
            {
                new Record
                {
                    Key = 1,
                    Value = "Value: 1"
                },
                new Record
                {
                    Key = 2,
                    Value = "Value: 2"
                },
                new Record
                {
                    Key = 3,
                    Value = "Value: 3"
                },
                new Record
                {
                    Key = 4,
                    Value = "Value: 4"
                },
                new Record
                {
                    Key = 5,
                    Value = "Value: 5"
                }
            }
        };
        [Test]
        public void GetRecordInBlockByKey_3_Return_Correct()
        {
            var key = 3;
            var excepted = block.Records[2];
            var actual = CRUD.GetRecordInBlockByKey(key, block);
            Assert.AreEqual(excepted, actual);
        }

        [Test]
        public void GetRecordInBlockByKey_6_Throw_Exception()
        {
            var key = 6;
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                CRUD.GetRecordInBlockByKey(key, block);
            });
        }

        [Test]
        public void GetBlocks_With_Empty_database_txt_Return_1_Block()
        {
            using var fs = new FileStream(CRUD.FileName, FileMode.Truncate, FileAccess.Write, FileShare.None);
            fs.Flush();
            fs.Dispose();
            var blocks = CRUD.GetBlocks();
            Assert.AreEqual(blocks.Count, 1);
        }

        [Test]
        public void GetBlocks_Return_Correct_Count_Blocks()
        {
            var blocks = CRUD.GetBlocks();
            if (blocks.Count > 1)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        [Test]
        public void GetBlockByKey_Return_Block_With_Correct_FirstIndex()
        {
            var actual = CRUD.GetBlockByKey(132);
            Assert.AreEqual(actual.FirstIndex, 100);
        }

        [Test]
        public void GetBlockByKey_Trow_Exception()
        {
            var key = 100000;
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                CRUD.GetBlockByKey(key);
            });
        }

        [Test]
        public void GetByKey_Return_Correct_Record()
        {
            var keys = new []{10, 150, 1456, 5678};
            foreach (var key in keys)
            {
                var actual = CRUD.GetByKey(key);
                Assert.AreEqual(actual.Key, key);
            } 
        }

        [Test]
        public void GetByKey_Throw_Exception()
        {
            var keys = new []{-1, 0, 100000};
            foreach (var key in keys)
            {
                Assert.Throws<IndexOutOfRangeException>(() =>
                {
                    CRUD.GetByKey(key);
                });
            } 
        }

        [Test]
        public void AddRecord_Correct_Work()
        {
            var excepted = "Value: excepted";
            var actual = CRUD.Add(excepted);
            Assert.AreEqual(excepted, actual.Value);
            actual = CRUD.GetByKey(actual.Key);
            Assert.AreEqual(actual.Value, excepted);
        }
    }
}