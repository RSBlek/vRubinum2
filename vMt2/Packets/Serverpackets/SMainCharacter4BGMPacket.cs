using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;
using vMt2.Models;

namespace vMt2.Packets.Serverpackets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_MAIN_CHARACTER4_BGM_VOL)]
    class SMainCharacter4BGMPacket : ServerPacket
    {
        private const int charname_len = 24;
        private const int musicname_len = 24;

        public UInt32 VID { get; set; }
        public Race Race { get; set; }
        public byte UnknownByte { get; set; }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = charname_len + 1)]
        public String Username;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = musicname_len + 1)]
        public String BGMName;

        public float BGMVol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Empire Empire { get; set; }
        public byte SkillGroup { get; set; }

        public override void Received(VirtualClient virtualClient)
        {
            MainCharacter mainCharacter = new MainCharacter()
            {
                VID = this.VID,
                Empire = this.Empire,
                Name = this.Username,
                Race = this.Race,
                SkillGroup = this.SkillGroup,
                X = this.X,
                Y = this.Y,
                Z = this.Z,
            };
            virtualClient.CharacterManager.SetCharacter(mainCharacter);
        }

    }
}
