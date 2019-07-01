using System;
using System.Collections.Generic;
using System.Text;
using vMt2.Enums;

namespace vMt2.Encryption
{
    class PacketEncoder
    {
        public EncryptionLevel EncryptionLevel { get; private set; } = EncryptionLevel.None;

        public void DecryptProxy(byte[] data)
        {
            if (this.EncryptionLevel == EncryptionLevel.None)
            {
                return;
            }
            else if (this.EncryptionLevel == EncryptionLevel.TEA)
            {

            }
        }

        public void SetEncryptionLevel(EncryptionLevel encryptionLevel)
        {
            this.EncryptionLevel = encryptionLevel;
        }

    }
}
