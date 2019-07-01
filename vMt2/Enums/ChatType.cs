using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2
{
    public enum ChatType : byte
    {
        TALKING,
        INFO,
        NOTICE,
        PARTY,
        GUILD,
        COMMAND,
        SHOUT,
        WHISPER,
        BIG_NOTICE,
        MAX_NUM,
    }
}
