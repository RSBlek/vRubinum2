using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Models;

namespace vMt2.Packets.Serverpackets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacket(ServerPacketHeader.HEADER_GC_QUICKSLOT_ADD)]
    class SQuickslotAddPacket : ServerPacket
    {
        public byte Pos { get; set; }
        public Quickslot Slot { get; set; }
        public override void Received(VirtualClient virtualClient)
        {

        }
    }
}
