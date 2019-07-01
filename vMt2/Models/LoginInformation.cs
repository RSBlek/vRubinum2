using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2
{
    internal class LoginInformation
    {
        public String Username { get; set; }
        public String Password { get; set; }
        internal UInt32? LoginKey { get; set; } = null;
    }
}
