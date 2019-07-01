using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets.Serverpackets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_CHARACTER_POINT_CHANGE)]
    class SPointChangePacket : ServerPacket
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] UnknownBytes;
        public UInt32 VID { get; set; }
        public byte Type { get; set; }
        public UInt32 Amount { get; set; }
        public UInt32 Value { get; set; }


        public override void Received(VirtualClient virtualClient)
        {
            
        }

    }
}
