using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_LAND_LIST)]
    class SLandListPacket : ServerPacket
    {
        [DynamicSize]
        public UInt16 Size;

        public override void Received(VirtualClient virtualClient)
        {
            UInt16 packetSize = (UInt16)(Size - Marshal.SizeOf<SLandListPacket>());
            byte[] packetBytes = virtualClient.DequeueReceivedData(packetSize);
        }

    }
}