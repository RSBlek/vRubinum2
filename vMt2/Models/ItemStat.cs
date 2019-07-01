using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ItemStat
    {
        public ItemStatType Type { get; set; }
        public Int16 Value { get; set; }
    }
}
