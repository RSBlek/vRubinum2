using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CItemMovePacket : ClientPacket
    {
        public byte SourceWindow { get; set; }
        public UInt16 SourceSlot { get; set; }
        public byte DestinationWindow { get; set; }
        public UInt16 DestinationSlot { get; set; }
        public UInt32 Count { get; set; }

        public CItemMovePacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_ITEM_MOVE;
        }
    }
}