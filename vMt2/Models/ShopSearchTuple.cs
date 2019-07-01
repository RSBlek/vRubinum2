using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2.Models
{
    public class ShopSearchTuple
    {
        public UInt32 ItemId { get; set; }
        public UInt32 ShopId { get; set; }
        public UInt16 ShopPosition { get; set; }
        public String Seller { get; set; }
        public UInt32 Count { get; set; }
        public UInt64 Price { get; set; }
        public String Hash { get; set; }
    }
}
