using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_SPECIFIC_EFFECT)]
    class SSpecificEffectPacket : ServerPacket
    {
        public UInt32 Vid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public String EffectFile;

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}