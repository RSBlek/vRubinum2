using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using vMt2.Packets;

namespace vMt2
{
    public partial class VirtualClient
    {
        internal byte SelectedCharacterIndex { get; private set; }

        public void SelectCharacter(byte characterIndex)
        {
            if (currentPhase != Phase.Select)
                throw new Exception("Not in selection phase");
            this.SelectedCharacterIndex = characterIndex;
            this.Disconnect();
            this.ResetSequence();
            this.Encryption = false;
            this.SetXteaKey(defaultXteaKey);
            IPEndPoint ipEndPoint = new IPEndPoint(LoginSuccessResult.Characters[characterIndex].Addr, LoginSuccessResult.Characters[characterIndex].Port);
            this.Connect(ServerEndPoint.GameServer, ipEndPoint);
        }
    }
}
