using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_AUTH_SUCCESS)]
    class SAuthSuccessPacket : ServerPacket
    {
        public UInt32 LoginKey { get; set; }
        public byte Result { get; set; }

        public override void Received(VirtualClient virtualClient)
        {
            virtualClient.Logger.LogInfo("Authentication success");
            virtualClient.Disconnect();
            virtualClient.Encryption = false;
            virtualClient.LoginInformation.LoginKey = LoginKey;
            virtualClient.Connect(ServerEndPoint.LoginServer);
        }

    }
}