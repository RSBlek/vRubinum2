using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PlayerSkill
    {
        public Byte MasterType;
        public Byte Level;
        public UInt64 NextRead;
    }
}
