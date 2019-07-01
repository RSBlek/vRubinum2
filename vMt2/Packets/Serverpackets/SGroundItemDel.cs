using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_GROUND_ITEM_DEL)]
    class SGroundItemDel : ServerPacket
    {
        public UInt32 Vid { get; set; }

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}