using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CShopAddItemPacket : ClientPacket
    {
        public byte SourceInventory;
        public UInt16 SourceSlot;
        public UInt32 DestinationSlot;
        public UInt64 Price;

        public CShopAddItemPacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_SHOP_ADD_ITEM;
        }
    }
}