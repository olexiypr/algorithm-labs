
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Laba1_1GB
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*Sort.CreateFile();*/
            string resPath = Sort.StartSort();
            Sort.CheckRes(resPath);
        }
    }
}