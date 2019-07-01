using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_EXCHANGE)]
    class SExchangePacket : ServerPacket
    {
        public byte SubHeader { get; set; }
        public byte IsMe { get; set; }
        public UInt64 Arg1 { get; set; }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Arg2;
        public UInt32 Arg3 { get; set; }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 142)]
        public byte[] UnknownBytes;

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}