using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;
using vMt2.Models;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_ITEM_SET)]
    class SItemSetPacket : ServerPacket
    {
        private const int socketslots_len = 3;
        public ItemPos Cell { get; set; }
        public UInt32 Vnum { get; set; }
        public UInt32 Count { get; set; }
        public UInt32 Transmutation { get; set; }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 136)]
        public byte[] UnknownBytes;

        public override void Received(VirtualClient virtualClient)
        {
            Inventory inventory = virtualClient.GetInventory(Cell.WindowType);

            if(inventory != null)
            {                  
                SlotItem slotItem = new SlotItem()
                {
                    Vnum = this.Vnum,
                    Count = this.Count
                };
                inventory.SetSlot(Cell.Cell, slotItem);
            }
        }

    }
}