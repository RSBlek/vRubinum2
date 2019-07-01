using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2.Encryption
{
    public static class TinyEncryptionAlgorithm
    {
        private static readonly UInt32 rounds = 32;
        private static UInt32 delta = 0x9E3779B9;

        private static byte[] Decode(UInt32 sz, UInt32 sy, ref UInt32[] key)
        {
            uint n = rounds;
            uint sum = delta * rounds;

            while (n-- > 0)
            {
                sz -= ((sy << 4 ^ sy >> 5) + sy) ^ (sum + key[sum >> 11 & 3]);
                sum -= delta;
                sy -= ((sz << 4 ^ sz >> 5) + sz) ^ (sum + key[sum & 3]);
            }
            byte[] output = new byte[8];
            Array.Copy(BitConverter.GetBytes(sy), 0, output, 0, 4);
            Array.Copy(BitConverter.GetBytes(sz), 0, output, 4, 4);
            return output;
        }

        private static byte[] Encode(UInt32 sz, UInt32 sy, ref UInt32[] key)
        {
            uint n = rounds;
            uint sum = 0;

            while (n-- > 0)
            {
                sy += ((sz << 4 ^ sz >> 5) + sz) ^ (sum + key[sum & 3]);
                sum += delta;
                sz += ((sy << 4 ^ sy >> 5) + sy) ^ (sum + key[sum >> 11 & 3]);
            }

            byte[] output = new byte[8];
            Array.Copy(BitConverter.GetBytes(sy), 0, output, 0, 4);
            Array.Copy(BitConverter.GetBytes(sz), 0, output, 4, 4);
            return output;
        }

        public static UInt32[] GetKeyArray(byte[] key)
        {
            UInt32[] keyArray = new UInt32[4];
            for (int i = 0; i < 4; i++)
            {
                keyArray[i] = BitConverter.ToUInt32(key, i * 4);
            }
            return keyArray;
        }

        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            int newSize = newSize = data.Length;
            byte[] resizedData;
            UInt32[] keyArray = GetKeyArray(key);

            if (data.Length % 8 == 0)
            {
                resizedData = data;
            }
            else
            {
                newSize = data.Length + 8 - (data.Length % 8);
                resizedData = new byte[newSize];
                Array.Copy(data, resizedData, data.Length);
            }
            byte[] encryptedData = new byte[newSize];

            int position = 0;
            for (int i = 0; i < (newSize >> 3); i++, position += 2)
            {
                Array.Copy(Encode(BitConverter.ToUInt32(resizedData, position * 4 + 4), BitConverter.ToUInt32(resizedData, position * 4), ref keyArray), 0, encryptedData, position * 4, 8);
            }

            return encryptedData;
        }

        public static byte[] Decrypt(byte[] data, byte[] key)
        {
            if (data.Length % 8 != 0)
                throw new Exception("For test purposes. Data for tea decryption should always be % 8 == 0");

            int newSize = data.Length;
            byte[] resizedData;
            UInt32[] keyArray = GetKeyArray(key);

            if (data.Length % 8 == 0)
            {
                resizedData = data;
            }
            else
            {
                newSize = data.Length + 8 - (data.Length % 8);
                resizedData = new byte[newSize];
                Array.Copy(data, resizedData, data.Length);
            }
            byte[] decryptedData = new byte[newSize];

            int position = 0;
            for (int i = 0; i < (newSize >> 3); i++, position += 2)
            {
                Array.Copy(Decode(BitConverter.ToUInt32(resizedData, position * 4 + 4), BitConverter.ToUInt32(resizedData, position * 4), ref keyArray), 0, decryptedData, position * 4, 8);
            }

            return decryptedData;
        }
    }
}
