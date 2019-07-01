using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2
{
    public class LoginFailResult
    {
        public LoginFailReason LoginFailReason { get; internal set; }
        public String Description { get; internal set; }
    }
}
