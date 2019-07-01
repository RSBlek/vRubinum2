using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace vMt2
{
    class NetworkInformation
    {
        internal IPEndPoint AuthenticationServer { get; set; }
        internal IPEndPoint LoginServer { get; set; }
    }
}
