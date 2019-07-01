using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2.Models
{
    public class SlotItem
    {
        public UInt32 Vnum { get; set; }
        public UInt32 Count { get; set; }
        public List<ItemStat> ItemStats { get; } = new List<ItemStat>();
    }
}
