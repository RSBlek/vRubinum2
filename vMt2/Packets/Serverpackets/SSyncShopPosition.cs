using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_SYNC_SHOP_POSITION)]
    class SSyncShopPositionPacket : ServerPacket
    {
        public int Channel { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override void Received(VirtualClient virtualClient)
        {
            
        }

    }
}