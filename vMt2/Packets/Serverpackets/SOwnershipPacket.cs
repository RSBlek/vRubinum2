using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_OWNERSHIP)]
    class SOwnershipPacket : ServerPacket
    {
        public UInt32 OwnerVid { get; set; }
        public UInt32 VictimVid { get; set; }
       

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}