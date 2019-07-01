using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_SHOP_SIGN)]
    class SShopSignPacket : ServerPacket
    {
        private const int sign_len = 32;
        public UInt32 Vid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = sign_len + 1)]
        public String Sign;
        public UInt16 ShopType;

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}