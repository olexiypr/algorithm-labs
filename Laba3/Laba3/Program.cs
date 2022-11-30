﻿using Laba3_UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3_UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FillDB(); //розкоментуйте цей рядок, якщо у вас немає запосненого файлу database.txt
            Application.Run(new Form1());
        }
        private static void FillDB ()
        {
            using var fs = new FileStream("database.txt", FileMode.OpenOrCreate);
            fs.Dispose();
            CRUD.Blocks = new List<Block>();
            CRUD.Blocks.Add(new Block
            {
                FirstIndex = 1,
                Records = new List<Record>()
            });
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
