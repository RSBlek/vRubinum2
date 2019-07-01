using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Quickslot
    {
        public byte Type { get; set; }
        public byte Position { get; set; }
    }
}
