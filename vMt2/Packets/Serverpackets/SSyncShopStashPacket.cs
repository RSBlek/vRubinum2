using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_SYNC_SHOP_STASH)]
    class SSyncShopStashPacket : ServerPacket
    {
        public UInt64 Value { get; set; }

        public override void Received(VirtualClient virtualClient)
        {
            virtualClient.CharacterManager.GetCharacter().ShopGold = Value;
        }

    }
}