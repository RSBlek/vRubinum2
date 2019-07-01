using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ItemPos
    {
        public byte WindowType { get; set; }
        public UInt16 Cell { get; set; }
    }
}
