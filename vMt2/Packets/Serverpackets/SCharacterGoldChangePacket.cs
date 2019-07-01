using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_CHARACTER_GOLD_CHANGE)]
    class SCharacterGoldChangedPacket : ServerPacket
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Unknownbytes;
        public UInt32 Vid { get; set; }
        public UInt64 Changed { get; set; }
        public UInt64 Gold { get; set; }

        public override void Received(VirtualClient virtualClient)
        {
            virtualClient.CharacterManager.GetCharacter().Gold = this.Gold;
            virtualClient.Logger.LogInfo("Gold: " + Gold);
        }
    }
}