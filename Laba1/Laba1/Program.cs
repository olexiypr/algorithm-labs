using System;
using System.Text;

namespace Laba1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Sort.CreateFile();
            Sort.StartSort();
            Sort.CheckRes();
        }
    }
}