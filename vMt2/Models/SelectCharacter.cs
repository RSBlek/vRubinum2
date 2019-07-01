using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SelectCharacter
    {
        public UInt32 ID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24 + 1)]
        public String Name;

        public Race Race;
        public Byte Level;
        public UInt32 PlayTime;
        public Byte Strength;
        public Byte Vitality;
        public Byte Dexterity;
        public Byte Intelligence;

        public UInt16 MainPart;
        public Byte ChangeName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] UnknownBytes;
        public Int32 X;
        public Int32 Y;
        public UInt32 Addr;
        public UInt16 Port;
        public Byte Skill;

        public UInt32 LastLoginTimestamp;
    }
}
