using System;
using System.Collections.Generic;
using System.Text;
using vMt2.Manager;
using vMt2.Models;

namespace vMt2
{
    public partial class VirtualClient
    {
        public CharacterManager CharacterManager { get; } = new CharacterManager();
        public ShopManager ShopManager { get; }

        public InventoryManager InventoryManager { get; }

        public Inventory GetInventory(byte id)
        {
            if (id == 1)
                return CharacterManager.GetCharacter().StandardInventory;
            else if (id == 0xC)
                return CharacterManager.GetCharacter().UpitemInventory;

            return null;
        }


    }
}
