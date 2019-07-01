using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    abstract class ClientPacket
    {
        public ClientPacketHeader PacketHeader { get; protected set; }
    }
}
