using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;
using vMt2.Models;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_ITEM_UPDATE)]
    class SItemUpdatePacket : ServerPacket
    {
        private const int socketslots_len = 3;
        public ItemPos Cell { get; set; }
        public UInt32 Count { get; set; }
        public UInt32 Transmutation { get; set; }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] UnknownBytes01;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        public byte[] StatBytes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] UnknownBytes02;

        public override void Received(VirtualClient virtualClient)
        {
            Inventory inventory = virtualClient.GetInventory(Cell.WindowType);
            if (inventory != null)
            {
                List<ItemStat> itemStats = new List<ItemStat>();
                for (int i = 0; i < StatBytes.Length; i = i + 3)
                {
                    ItemStatType type = (ItemStatType)StatBytes[i];
                    Int16 value = BitConverter.ToInt16(StatBytes, i + 1);
                    if (type != ItemStatType.None)
                        itemStats.Add(new ItemStat() { Type = type, Value = value });
                }
                inventory.UpdateItem(Cell.Cell, Count, itemStats);
                virtualClient.OnSlotChanged(Cell.WindowType, Cell.Cell, inventory.Slots[Cell.Cell]);
            }
        }

    }
}