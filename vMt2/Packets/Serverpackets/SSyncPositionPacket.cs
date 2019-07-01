using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;
using vMt2.Models;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_SYNC_POSITION)]
    class SSyncPositionPacket : ServerPacket
    {
        [DynamicSize]
        public UInt16 Size;

        public override void Received(VirtualClient virtualClient)
        {
            UInt16 packetSize = (UInt16)(Size - Marshal.SizeOf<SSyncPositionPacket>());
            if (packetSize > 0)
                virtualClient.DequeueReceivedData(packetSize);
        }

    }
}