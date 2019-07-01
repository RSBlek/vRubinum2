using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CSentrySendPacket : ClientPacket
    {
        private const int sentry_len = 256;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = sentry_len + 1)]
        public String Mac;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = sentry_len + 1)]
        public String Guid;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = sentry_len + 1)]
        public String HddSer;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = sentry_len + 1)]
        public String CpuId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = sentry_len + 1)]
        public String HddMod;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16 + 1)]
        public String DeviceName;
        public CSentrySendPacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_SENTRY_PARAMETERS;
        }
    }
}