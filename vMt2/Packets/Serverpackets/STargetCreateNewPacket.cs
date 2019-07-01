using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_TARGET_CREATE_NEW)]
    class STargetCreateNewPacket : ServerPacket
    {
        public Int32 Id;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public String TargetName;
        public UInt32 Vid;
        public byte Type;

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}