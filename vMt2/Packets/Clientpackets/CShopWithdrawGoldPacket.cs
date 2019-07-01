using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CShopWithdrawGoldPacket : ClientPacket
    {
        public UInt64 Amount;

        public CShopWithdrawGoldPacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_SHOP_WITHDRAW_GOLD;
        }
    }
}