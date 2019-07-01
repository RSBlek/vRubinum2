using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Enums;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_LOGIN_FAILURE)]
    class SLoginFailurePacket : ServerPacket
    {
        private const int status_len = 104; //Correct?
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = status_len + 1)]
        public String Status;

        public override void Received(VirtualClient virtualClient)
        {
            LoginFailResult result = new LoginFailResult
            {
                LoginFailReason = LoginFailReason.Description,
                Description = this.Status
            };
            virtualClient.OnLoginFail(result);
        }

    }
}