using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CShopSearchQueryPacket : ClientPacket
    {
        private const int itemname_len = 40;
        private const int category_len = 19;

        public byte UnknownByte = 0x01;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = itemname_len + 1)]
        public String Itemname;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = category_len + 1)]
        public String Category = "root";

        public UInt16 Unknown01 = 1;
        public UInt16 Unknown02 = 0x78;
        public UInt16 Unknown03 = 0xFFFF;
        public UInt32 Unknown04 = 0x0064FF9C;
        public UInt32 Unknown05 = 0x0064FF9C;
        public UInt32 Unknown06 = 0xFFFFFFFF;
        public UInt16 Unknown07 = 0x0;
        public UInt16 Unknown08 = 0xFFFF;
        public UInt16 PageSize = 150;


        public CShopSearchQueryPacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_SHOP_SEARCH_QUERY;
        }
    }
}