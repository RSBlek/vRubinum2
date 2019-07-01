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
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_NPC_POSITION)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_Shop_POSITION)]
    class SNPCPositionPacket : ServerPacket
    {
        [DynamicSize]
        public UInt16 Size;
        public UInt16 Count;

        public override void Received(VirtualClient virtualClient)
        {
            UInt16 packetSize = (UInt16)(Size - Marshal.SizeOf<SNPCPositionPacket>());
            byte[] packetBytes = virtualClient.DequeueReceivedData(packetSize);

            List<NPCPosition> npcPositions = new List<NPCPosition>(Count);
            int npcPositionSize = Marshal.SizeOf<NPCPosition>();
            for (int i = 0; i < npcPositionSize * Count; i = i + npcPositionSize)
            {
                byte[] npcPositionBytes = new byte[npcPositionSize];
                Array.Copy(packetBytes, i, npcPositionBytes, 0, npcPositionSize);
                GCHandle handle = GCHandle.Alloc(npcPositionBytes, GCHandleType.Pinned);
                NPCPosition npcPosition = (NPCPosition)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(NPCPosition));
                handle.Free();
                npcPositions.Add(npcPosition);
            }
        }

    }
}