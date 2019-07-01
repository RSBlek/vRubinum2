using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_EXCHANGE_INFO)]
    class SExchangeInfoPacket : ServerPacket
    {
        [DynamicSize]
        public UInt16 Size;
        public bool Error;
        public UInt32 UnixTime;

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}