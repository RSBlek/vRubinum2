using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacket(ServerPacketHeader.HEADER_GC_SCRIPT)]
    class SScriptPacket : ServerPacket
    {
        [DynamicSize]
        public UInt16 Size;
        public byte Skin;
        public UInt16 SourceSize;
        public byte QuestFlag;

        public override void Received(VirtualClient virtualClient)
        {
            UInt16 packetLength = (UInt16)(Size - Marshal.SizeOf<SScriptPacket>());
            byte[] packetBytes = virtualClient.DequeueReceivedData(packetLength);
            
        }
    }
}