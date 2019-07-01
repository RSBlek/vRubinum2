using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2.Models
{
    public class Inventory
    {
        public List<SlotItem> Slots { get; } 
        public Inventory(UInt16 size)
        {
            Slots = new List<SlotItem>(size);
            for(int i = 0; i < size; i++)
            {
                Slots.Add(null);
            }
        }

        public void SetSlot(UInt16 slot, SlotItem slotItem)
        {
            if (slotItem.Vnum == 0)
                Slots[slot] = null;
            else
                Slots[slot] = slotItem;
        }

        public void UpdateItem(UInt16 slot, UInt32 count, List<ItemStat> stats)
        {
            if (Slots[slot] != null)
            {
                Slots[slot].Count = count;
                Slots[slot].ItemStats.Clear();
                Slots[slot].ItemStats.AddRange(stats);
            }
                

        }
    }
}
