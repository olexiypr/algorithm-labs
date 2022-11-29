using System;
using System.Collections.Generic;

namespace Laba3
{
    [Serializable]
    public class Block
    {
        public int FirstIndex { get; set; }
        public List<Record> Records { get; set; }
    }
}