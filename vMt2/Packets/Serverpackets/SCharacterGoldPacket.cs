using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_CHARACTER_GOLD)]
    class SCharacterGoldPacket : ServerPacket
    {
        public UInt64 Gold { get; set; }

        public override void Received(VirtualClient virtualClient)
        {
            if(virtualClient.IsIngame == false)
            {
                CEnterGamePacket packet = new CEnterGamePacket();
                virtualClient.SendPacket(packet);
                virtualClient.Logger.LogInfo("Entered Game");
                virtualClient.IsIngame = true;
            }
            virtualClient.CharacterManager.GetCharacter().Gold = this.Gold;;
            virtualClient.Logger.LogInfo("Gold: " + Gold);
        }
    }
}