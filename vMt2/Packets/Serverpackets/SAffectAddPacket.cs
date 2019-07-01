using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_AFFECT_ADD)]
    class SAffectAddPacket : ServerPacket
    {
        public UInt32 Type { get; set; }
        public byte PointIdApplyOn { get; set; }
        public Int32 ApplyValue { get; set; }
        public UInt32 Flag { get; set; }
        public Int32 Duration { get; set; }
        public Int32 SPCost { get; set; }
       

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}