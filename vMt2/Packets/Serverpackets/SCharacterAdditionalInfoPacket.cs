using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_CHAR_ADDITIONAL_INFO)]
    class SCharacterAdditionalInfoPacket : ServerPacket
    {
        private const int charname_len = 24;

        public UInt32 Vid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = charname_len + 1)]
        public String Name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public UInt32[] Parts;
        public Empire Empire;
        public UInt32 Guild;
        public UInt32 Level;
        public UInt16 Alignment;
        public byte PKMode;
        public UInt32 MountVid;
        public UInt32 Arrow;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public String Country;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 173)]
        public byte[] UnknownBytes;

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}