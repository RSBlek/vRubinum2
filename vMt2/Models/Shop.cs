using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2.Models
{
    public class Shop
    {
        public List<ShopSlot> ShopSlots { get; }
        public Shop(int size)
        {
            ShopSlots = new List<ShopSlot>(size);
            for (int i = 0; i < size; i++)
                ShopSlots.Add(null);
        }

        public void Resize(uint size)
        {
            while (ShopSlots.Count != size)
            {
                if (ShopSlots.Count < size)
                    ShopSlots.Add(null);
                else if (ShopSlots.Count > size)
                    ShopSlots.RemoveAt(ShopSlots.Count - 1);
            }
        }

        public void SetSlot(byte slot, UInt32 vnum, UInt32 count, UInt64 price)
        {
            if (vnum == 0)
                ShopSlots[slot] = null;
            else
            {
                ShopSlot shopSlot = new ShopSlot()
                {
                    Count = count,
                    Price = price,
                    Vnum = vnum
                };
                ShopSlots[slot] = shopSlot;
            }
        }

    }
}
