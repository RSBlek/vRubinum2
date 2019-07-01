using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CItemUseToItemPacket : ClientPacket
    {
        public byte SourceWindow;
        public UInt16 SourceSlot;
        public byte DestinationWindow;
        public UInt16 DestinationSlot;

        public CItemUseToItemPacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_ITEM_USE_TO_ITEM;
        }
    }
}