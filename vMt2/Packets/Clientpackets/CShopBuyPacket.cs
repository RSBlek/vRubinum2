using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CShopBuyPacket : ClientPacket
    {
        public UInt32 ShopId;
        public UInt32 ShopPosition;

        public CShopBuyPacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_SHOP_BUY;
        }
    }
}