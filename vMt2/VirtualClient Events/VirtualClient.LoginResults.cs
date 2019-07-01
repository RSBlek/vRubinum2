using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace vMt2
{
    public partial class VirtualClient
    {
        public delegate void LoginSuccessHandler(VirtualClient virtualClient, LoginSuccessResult loginResult);
        public delegate void LoginFailHandler(VirtualClient virtualClient, LoginFailResult loginResult);
        public event LoginSuccessHandler LoginSuccessCallback;
        public event LoginFailHandler LoginFailCallback;

        internal void OnLoginSuccess()
        {
            LoginSuccessCallback?.Invoke(this, LoginSuccessResult);
        }

        internal void OnLoginFail(LoginFailResult loginFailResult)
        {
            LoginFailCallback?.Invoke(this, loginFailResult);
        }

    }
}
