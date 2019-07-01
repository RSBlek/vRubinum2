using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacket(ServerPacketHeader.HEADER_GC_CHAT)]
    class SChatPacket : ServerPacket
    {
        [DynamicSize]
        public UInt16 Size;
        public ChatType ChatType;
        public UInt32 Vid;
        public Empire Empire;

        public override void Received(VirtualClient virtualClient)
        {
            UInt16 packetSize = (UInt16)(Size - Marshal.SizeOf<SChatPacket>());
            byte[] packetBytes = virtualClient.DequeueReceivedData(packetSize);
        }
    }
}