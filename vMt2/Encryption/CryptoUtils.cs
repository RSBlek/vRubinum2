using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2.Encryption
{
    public class CryptoUtils
    {
        public static byte[] GetKey_20050304Myevan()
        {
            UInt32[] key = new UInt32[1938];
            UInt32 seed = 1275341478;
            byte b = (byte)seed;

            for(int i = 0; i<b; i++)
            {
                seed ^= 2682154955;
                seed += 3984269856;
                key[i] = seed;
            }

            byte[] result = new byte[16];
            Buffer.BlockCopy(key, 13, result, 0, result.Length);

            return result;
        }

    }
}
