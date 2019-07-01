using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_GROUND_ITEM_ADD)]
    class SGroundItemAdd : ServerPacket
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Int32 Z { get; set; }
        public Int32 Socket0 { get; set; }
        public Int32 Socket1 { get; set; }
        public Int32 Socket2 { get; set; }
        public UInt32 Vid { get; set; }
        public UInt32 VNum { get; set; }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public byte[] UnknownBytes;
       

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}