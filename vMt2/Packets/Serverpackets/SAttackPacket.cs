using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_ATTACK)]
    class SAttackPacket : ServerPacket
    {
        public byte Type { get; set; }
        public UInt32 Victim { get; set; }
        public byte CRCMagicCubeProcPiece { get; set; }
        public byte CRCMagicCubeFilePiece { get; set; }


        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}