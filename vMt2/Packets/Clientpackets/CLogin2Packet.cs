using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CLogin2Packet : ClientPacket
    {
        private const int username_len = 30;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = username_len + 1)]
        public String Username;

        public UInt32 LoginKey;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public UInt32[] ClientKey = new UInt32[4];

        public CLogin2Packet()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_LOGIN2;
        }
    }
}