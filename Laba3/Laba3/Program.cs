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
            Application.Run(new Form1());
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
            CRUD.Blocks = new List<Block>
            {
                new Block
                {
                    FirstIndex = 1,
                    Records = new List<Record>()
                }
            };
            for (int i = 1; i < 50; i++)
            {
                CRUD.Blocks[0].Records.Add(new Record
                {
                    Key = i,
                    Value = "Value: " + i
                });
            }
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
                CRUD.Blocks.Add(block);
            }
            CRUD.WriteBlocks();
        }
    }
}
