using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_CHARACTER_MOVE)]
    class SMovePacket : ServerPacket
    {
        public byte Func;
        public byte Arg;
        public byte Rotation;
        public UInt32 Vid;
        public Int32 X;
        public Int32 Y;
        public UInt32 Time;
        public UInt32 Duration;
        public override void Received(VirtualClient virtualClient)
        {
        }
    }
}