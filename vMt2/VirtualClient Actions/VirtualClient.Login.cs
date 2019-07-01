using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace vMt2
{
    public partial class VirtualClient
    {
        internal LoginInformation LoginInformation { get; } = new LoginInformation();
        internal LoginSuccessResult LoginSuccessResult { get; private set; }

        public void Login(String username, String password)
        {
            //for (int i = 0; i < 4; i++)
            //    ClientKey[i] = (UInt32)random.Next();

            ClientKey[0] = 0xAAAAAAAA;
            ClientKey[1] = 0xBBBBBBBB;
            ClientKey[2] = 0xCCCCCCCC;
            ClientKey[3] = 0xDDDDDDDD;

            this.LoginSuccessResult = new LoginSuccessResult();
            this.LoginSuccessResult.Username = username;

            this.LoginInformation.Username = username;
            this.LoginInformation.Password = password;
            this.Connect(ServerEndPoint.AuthServer);
        }
    }
}
