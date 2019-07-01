using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_SHOP_RESULT)]
    class SShopResultPacket : ServerPacket
    {
        public UInt32 ItemId { get; set; }
        public UInt32 ItemCount { get; set; }
        public byte UnknownByte { get; set; }
        public UInt16 ShopPosition { get; set; }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 135)]
        public byte[] Unknown;

        public UInt32 ShopId { get; set; }
        public UInt64 Price { get; set; }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public String SellerName;


        public override void Received(VirtualClient virtualClient)
        {
            virtualClient.ShopManager.ResultReceived(this);
        }

    }
}