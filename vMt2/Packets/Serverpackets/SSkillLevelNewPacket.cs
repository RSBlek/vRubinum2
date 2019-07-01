using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_SKILL_LEVEL_NEW)]
    class SSkillLevelNewPacket : ServerPacket
    {
        private const int skills_len = 255;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = skills_len)]
        public PlayerSkill[] PlayerSkills;

        public override void Received(VirtualClient virtualClient)
        {
        }

    }
}