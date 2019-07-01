using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_EMPIRE)]
    class SEmpirePacket : ServerPacket
    {
        public Empire Empire { get; set; }

        public override void Received(VirtualClient virtualClient)
        {
            virtualClient.LoginSuccessResult.Empire = this.Empire;
        }
    }
}