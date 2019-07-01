using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_CHARACTER_UPDATE)]
    class SCharacterUpdatePacket : ServerPacket
    {
        private const int charname_len = 24;

        public UInt32 Vid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public UInt32[] Parts;
        public byte MovingSpeed;
        public byte ByteSpeed;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] UnknownBytes01;

        public UInt32 Guild;
        public UInt16 Alignment;
        public UInt32 Level;

        public byte PKMode;
        public UInt32 MountVid;
        public UInt32 Arrow;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public String Country;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 144)]
        public byte[] UnknownBytes02;

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}