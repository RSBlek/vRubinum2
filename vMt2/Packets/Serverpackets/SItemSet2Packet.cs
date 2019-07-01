using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;
using vMt2.Models;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_ITEM_SET2)]
    class SItemSet2Packet : ServerPacket
    {
        private const int socketslots_len = 3;
        public ItemPos Cell { get; set; }
        public UInt32 Vnum { get; set; }
        public UInt32 Count { get; set; }
        public UInt32 Transmutation { get; set; }
        public UInt32 Flags { get; set; }
        public UInt32 AntiFlags { get; set; }
        public UInt32 SealDate { get; set; }
        public byte Hightlight { get; set; }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] UnknownBytes01;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        public byte[] StatBytes;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 90)]
        public byte[] UnknownBytes;

        public override void Received(VirtualClient virtualClient)
        {
            Inventory inventory = virtualClient.GetInventory(Cell.WindowType);

            if (inventory != null)
            {
                SlotItem slotItem = new SlotItem()
                {
                    Vnum = this.Vnum,
                    Count = this.Count
                };
                for (int i = 0; i < StatBytes.Length; i = i + 3)
                {
                    ItemStatType type = (ItemStatType)StatBytes[i];
                    Int16 value = BitConverter.ToInt16(StatBytes, i + 1);
                    if (type != ItemStatType.None)
                        slotItem.ItemStats.Add(new ItemStat() { Type = type, Value = value });
                }
                inventory.SetSlot(Cell.Cell, slotItem);
                virtualClient.OnSlotChanged(Cell.WindowType, Cell.Cell, inventory.Slots[Cell.Cell]);
            }
        }

    }
}