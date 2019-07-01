using System;
using System.Collections.Generic;
using System.Text;
using vMt2.Packets;

namespace vMt2.Manager
{
    public class InventoryManager
    {
        private readonly VirtualClient virtualClient;
        public InventoryManager(VirtualClient virtualClient)
        {
            this.virtualClient = virtualClient;
        }

        public void MoveItem(byte srcWindow, UInt16 srcSlot, byte dstWindow, UInt16 dstSlot, UInt32 count)
        {
            CItemMovePacket packet = new CItemMovePacket()
            {
                Count = count,
                DestinationSlot = dstSlot,
                DestinationWindow = dstWindow,
                SourceSlot = srcSlot,
                SourceWindow = srcWindow
            };
            virtualClient.SendPacket(packet);
        }

        public void UseItemToItem(byte srcWindow, UInt16 srcSlot, byte dstWindow, UInt16 dstSlot)
        {
            CItemUseToItemPacket packet = new CItemUseToItemPacket()
            {
                DestinationSlot = dstSlot,
                DestinationWindow = dstWindow,
                SourceSlot = srcSlot,
                SourceWindow = srcWindow
            };
            virtualClient.SendPacket(packet);
        }

    }
}
