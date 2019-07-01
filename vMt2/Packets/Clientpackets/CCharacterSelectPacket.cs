using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CCharacterSelectPacket : ClientPacket
    {
        public byte CharacterIndex;

        public CCharacterSelectPacket()
        {
            this.PacketHeader = ClientPacketHeader.HEADER_CG_CHARACTER_SELECT;
        }
    }
}