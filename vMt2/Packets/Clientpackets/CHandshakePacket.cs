using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CHandshakePacket : ClientPacket
    {
        public UInt32 Handshake;
        public UInt32 Timestamp;
        public UInt32 Delta;

        public CHandshakePacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_HANDSHAKE;
        }
    }
}