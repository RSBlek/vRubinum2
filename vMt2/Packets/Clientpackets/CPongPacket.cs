using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CPongPacket : ClientPacket
    {
        public CPongPacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_PONG;
        }
    }
}