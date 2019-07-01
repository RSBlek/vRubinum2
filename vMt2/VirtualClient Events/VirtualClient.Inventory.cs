using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using vMt2.Models;

namespace vMt2
{
    public partial class VirtualClient
    {
        public delegate void ItemSlotChangedDelegate(VirtualClient virtualClient, byte window, UInt16 slot,SlotItem slotItem);
        public event ItemSlotChangedDelegate ItemSlotChangedCallback;

        internal void OnSlotChanged(byte window, UInt16 slot, SlotItem slotItem)
        {
            ItemSlotChangedCallback?.Invoke(this, window, slot, slotItem);
        }

    }
}
