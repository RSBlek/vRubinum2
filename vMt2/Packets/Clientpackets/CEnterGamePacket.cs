using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CEnterGamePacket : ClientPacket
    {
        public byte CharacterIndex;

        public CEnterGamePacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_ENTER_GAME;
        }
    }
}