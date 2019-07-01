using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace vMt2
{
    public partial class VirtualClient
    {
        public delegate void ChatHandler(VirtualClient virtualClient, ChatType chatType, string message, DateTime timestamp);
        public event ChatHandler MessageReceivedCallback;

        internal void OnMessageReceived(ChatType chatType, string message, DateTime timestamp)
        {
            MessageReceivedCallback?.Invoke(this, chatType, message, timestamp);
        }

    }
}
