using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_TARGET_UPDATE)]
    class STargetUpdatePacket : ServerPacket
    {
        public Int32 Id { get; set; }
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
       

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}