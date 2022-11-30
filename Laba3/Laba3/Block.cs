using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_UI
{
    [Serializable]
    public class Block
    {
        public int FirstIndex { get; set; }
        public List<Record> Records { get; set; }
    }

}
