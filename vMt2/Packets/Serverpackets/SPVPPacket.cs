using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_PVP)]
    class SPVPPacket : ServerPacket
    {
        public UInt32 VidSource { get; set; }
        public UInt32 VidDestination { get; set; }
        public byte Type { get; set; }
       

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}