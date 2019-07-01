using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CShopGetResultsPacket : ClientPacket
    {
        public UInt32 ResultOffset;

        public CShopGetResultsPacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_SHOP_GET_RESULTS;
        }
    }
}