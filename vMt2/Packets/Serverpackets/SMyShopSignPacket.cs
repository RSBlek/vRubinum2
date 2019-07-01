using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_MY_SHOP_SIGN)]
    class SMyShopSignPacket : ServerPacket
    {
        private const int shopsign_len = 32;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = shopsign_len + 1)]
        public String Sign;

        public override void Received(VirtualClient virtualClient)
        {
            
        }

    }
}