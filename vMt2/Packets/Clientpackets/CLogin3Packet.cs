using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CLogin3Packet : ClientPacket
    {
        private const int username_len = 30;
        private const int password_len = 16;
        private const int timestamp_len = 32;
        private const int hwid_len = 64;
        private const int lang_len = 4;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = username_len + 1)]
        public String Username;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = password_len + 1)]
        public String Password;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public UInt32[] ClientKey = new UInt32[4];

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = timestamp_len + 1)]
        public String Timestamp;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = hwid_len + 1)]
        public String HWID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = lang_len + 1)]
        public String Language;

        public CLogin3Packet()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_LOGIN3;
        }
    }
}