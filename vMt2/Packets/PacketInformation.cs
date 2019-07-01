using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace vMt2.Packets
{
    class PacketInformation
    {
        public ServerPacketHeader PacketHeader { get; }
        public Type PacketType { get; set; }
        public Int32 Size { get; set; }
        public FieldInfo DynamicSizeField { get; set; }
        public PacketInformation(ServerPacketHeader packetHeader)
        {
            this.PacketHeader = packetHeader;
        }
    }
}
