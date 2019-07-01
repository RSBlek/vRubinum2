using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_CHARACTER_ADD)]
    class SCharacterAddPacket : ServerPacket
    {
        public UInt32 Vid { get; set; }
        public float Angle { get; set; }
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Int32 Z { get; set; }
        public byte Type { get; set; }
        public Race Race { get; set; }
        public byte Movespeed { get; set; }
        public byte Attackspeed { get; set; }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public byte[] UnknownBytes;

        public override void Received(VirtualClient virtualClient)
        {

        }

    }
}