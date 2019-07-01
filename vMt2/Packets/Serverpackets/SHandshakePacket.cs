using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_HANDSHAKE)]
    class SHandshakePacket : ServerPacket
    {
        public UInt32 Handshake { get; set; }
        public UInt32 Timestamp { get; set; }
        public UInt32 Delta { get; set; }

        public override void Received(VirtualClient virtualClient)
        {
            CHandshakePacket packet = new CHandshakePacket();
            packet.Handshake = this.Handshake;
            packet.Timestamp = this.Timestamp + (Delta * 2);
            packet.Delta = 0;
            //packet.Handshake = this.Handshake;
            //packet.Token = new UInt32[8];
            //packet.Token[0] = this.Token;
            //for (uint i = 1; i < 8; i++)
            //{
            //    packet.Token[i] = packet.Token[i - 1] >> 0x1E;
            //    packet.Token[i] = packet.Token[i - 1] ^ packet.Token[i];
            //    packet.Token[i] = packet.Token[i] * 0x6C078965;
            //    packet.Token[i] = packet.Token[i] + i;
            //}

            //UInt32 x, y, z, w, v;
            //for (uint i = 0; i < 8; i++)
            //{
            //    x = ((packet.Token[i] >> 0x0B) ^ packet.Token[i]);
            //    y = (x & 0xFF3A58AD) << 0x7;
            //    z = x ^ y;
            //    x = ((z & 0xFFFFDF8C) << 0xF) ^ z;
            //    x = (x >> 0x12) ^ x;
            //    packet.Token[i] = x;
            //}

            //UInt32[] valTable = new UInt32[]
            //{
            //    0x93821DFC,
            //    0x879163AC,
            //    0xCA34E2D3,
            //    0x0AFECD69,
            //    this.Token,
            //    0x3CA3D70B
            //};

            //for (uint i = 0; i < 4; i++)
            //{
            //    UInt32 first = packet.Token[i * 2];
            //    UInt32 second = packet.Token[i * 2 + 1];
            //    UInt32 sum = 0;
            //    for (uint j = 0; j < 20; j++)
            //    {
            //        x = second << 0x4;
            //        y = second >> 0x5;
            //        x = x ^ y;
            //        z = sum & 0x4;
            //        x = x + second;
            //        y = valTable[z];
            //        w = sum + y;
            //        sum = sum - 0x648C8967;
            //        x = x ^ w;
            //        first = x + first;
            //        v = (first << 0x4) ^ (first >> 0x5);
            //        y = (sum >> 0xB);
            //        z = first + v;
            //        y = valTable[y & 0x4];
            //        w = sum + y;
            //        w = w ^ z;
            //        w = w + second;
            //        second = w;
            //    }
            //    packet.Token[i * 2] = first;
            //    packet.Token[i * 2 + 1] = second;
            //}
            virtualClient.SendPacket(packet);
        }
    }
}