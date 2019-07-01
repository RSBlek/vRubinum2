using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class GamePacketAttribute : Attribute
    {
        public ServerPacketHeader PacketHeader { get; }

        public GamePacketAttribute(ServerPacketHeader packetHeader)
        {
            this.PacketHeader = packetHeader;
        }
    }
}
