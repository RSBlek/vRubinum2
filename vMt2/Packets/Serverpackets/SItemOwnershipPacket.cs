using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_ITEM_OWNERSHIP)]
    class SItemOwnershipPacket : ServerPacket
    {
        private const int charname_len = 24;

        public UInt32 Vid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = charname_len + 1)]
        public String Name;

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}