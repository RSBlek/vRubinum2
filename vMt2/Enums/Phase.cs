using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2
{
    enum Phase : byte
    {
        Close = 0,
        Handshake = 1,
        Login = 2,
        Select = 3,
        Loading = 4,
        Game = 5,
        Dead = 6,
        DBClient_Connecting = 7,
        DBClient = 8,
        P2P = 9,
        AUTH = 10,
        SENTRY = 11,
    }
}
