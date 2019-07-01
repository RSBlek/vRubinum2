using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_PLAYER_SHOP_SET)]
    class SPlayerShopSetPacket : ServerPacket
    {
        public Byte Slot;
        public UInt32 Vnum;
        public UInt32 Count;
        public UInt64 Price;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 142)] 
        public byte[] UnknownBytes; //Slots and Stats

        public override void Received(VirtualClient virtualClient)
        {
            virtualClient.CharacterManager.GetCharacter().Shop.SetSlot(Slot, Vnum, Count, Price);
        }

    }
}