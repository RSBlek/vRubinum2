using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2.Models
{
    public class MainCharacter : Entity
    {
        public String Name { get; set; }
        public UInt64 Gold { get; set; }
        public UInt64 ShopGold { get; set; }
        public Race Race { get; set; }
        public Byte SkillGroup { get; set; }
        public Empire Empire { get; set; }
        public Shop Shop { get; } = new Shop(180);
        public Inventory StandardInventory { get; } = new Inventory(250);
        public Inventory UpitemInventory { get; } = new Inventory(225);
    }
}
