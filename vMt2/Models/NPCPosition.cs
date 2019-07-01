using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct NPCPosition
    {
        private const int charname_len = 24;
        public NPCType Type;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = charname_len + 1)]
        public String Name;
        public int X;
        public int Y;
    }
}
