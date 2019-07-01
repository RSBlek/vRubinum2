using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_LOGIN_SUCCESS4)]
    class SLoginSuccess4Packet : ServerPacket
    {
        private const int playerPerAccount = 5;
        private const int guildName_len = 20;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = playerPerAccount)]
        public SelectCharacter[] Characters = new SelectCharacter[playerPerAccount];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = playerPerAccount)]
        public UInt32[] GuildId = new UInt32[playerPerAccount];

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = playerPerAccount * (guildName_len + 1))]
        public String GuildNames;

        public UInt32 Handle;

        public UInt32 RandomKey;

        public override void Received(VirtualClient virtualClient)
        {
            if (virtualClient.ConnectedServerEndPoint != ServerEndPoint.GameServer)
            {
                virtualClient.LoginSuccessResult.Characters.AddRange(this.Characters.Where(x => x.ID != 0).ToList());
                String logtext = "";
                for(int i = 0; i<virtualClient.LoginSuccessResult.Characters.Count; i++)
                {
                    SelectCharacter character = virtualClient.LoginSuccessResult.Characters[i];
                    logtext += i + ") Name: " + character.Name + " Level: " + character.Level + " Race: " + character.Race + "\r\n";
                }
                    
                virtualClient.Logger.LogInfo(logtext);
                virtualClient.OnLoginSuccess();
            }
            else
            {
                CCharacterSelectPacket packet = new CCharacterSelectPacket();
                packet.CharacterIndex = virtualClient.SelectedCharacterIndex;
                virtualClient.SendPacket(packet);
            }

        }

    }
}