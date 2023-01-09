using Laba3_UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3_UI
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FillDB();
            Application.Run(new MainForm());
        }
        public static void FillDB ()
        {
            using var fs = new FileStream("database.txt", FileMode.OpenOrCreate);
            var fileInfo = new FileInfo("database.txt");
            if (fileInfo.Length > 0)
            {
                return;
            }
            fs.Dispose();
            CRUD.GetCRUD().Blocks = new List<Block>
            {
                new Block
                {
                    FirstIndex = 1,
                    Records = new List<Record>()
                }
            };
            FillBlocks();
        }

        private static void FillFirstBlock()
        {
            for (int i = 1; i < 50; i++)
            {
                CRUD.GetCRUD().Blocks[0].Records.Add(new Record
                {
                    Key = i,
                    Value = "Value: " + i
                });
            }
        }

        private static void FillBlocks()
        {
            FillFirstBlock();
            for (int i = 0; i < 10000; i+= 50)
            {
                var block = new Block
                {
                    FirstIndex = i,
                    Records = new List<Record>()
                };
                for (int j = 0; j < 50; j++)
                {
                    block.Records.Add(new Record
                    {
                        Key = i + j,
                        Value = "Value: " + (i + j)
                    });
                }
                CRUD.GetCRUD().Blocks.Add(block);
            }
            CRUD.GetCRUD().WriteBlocks();
        }
    }
}
