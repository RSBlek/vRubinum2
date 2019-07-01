using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_CHARACTER_POINTS)]
    class SCharacterPointsPacket : ServerPacket
    {
        private const int pointnum_len = 255;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = pointnum_len)]
        public UInt32[] Points;

        public override void Received(VirtualClient virtualClient)
        {
        }
    }
}