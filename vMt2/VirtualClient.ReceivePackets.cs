using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using vMt2.Encryption;
using vMt2.Packets;

namespace vMt2
{
    public partial class VirtualClient
    {
        private readonly ByteQueue newData = new ByteQueue();
        private readonly ByteQueue decryptedData = new ByteQueue();
        private readonly PacketParser packetParser = new PacketParser();

        internal bool Encryption { get; set; } = false;

        private void DataReceived(byte[] data)
        {
            newData.Enqueue(data);
            DecryptNewData();
            ProcessReceivedData();
        }

        private UInt16 GetDynamicSize(ServerPacket packet, PacketInformation packetInformation)
        {
            if (packetInformation.DynamicSizeField != null)
            {
                return (UInt16)packetInformation.DynamicSizeField.GetValue(packet);
            }
            return 0;
        }

        private void DecryptNewData()
        {
            if (Encryption == false)
            {
                //logger.Log("Received: ", newData.Peek(newData.Count));
                decryptedData.Enqueue(newData.Dequeue(newData.Count));
            }
            else if (Encryption == true && newData.Count >= 8)
            {
                int bytesToDecrypt = newData.Count >> 3;
                bytesToDecrypt = bytesToDecrypt << 3;
                byte[] decrypted = TinyEncryptionAlgorithm.Decrypt(newData.Dequeue(bytesToDecrypt), XTeaDecryptKey);
                Logger.LogDebug("Received raw: ", decrypted);
                decryptedData.Enqueue(decrypted);
            }
        }

        internal byte[] DequeueReceivedData(int count)
        {
            return decryptedData.Dequeue(count);
        }

        private void RemoveDecryptionTail()
        {
            while (decryptedData.Count > 0)
            {
                if (decryptedData.Peek() == 0)
                    decryptedData.Skip(1);
                else
                    return;
            }

        }

        private PacketInformation GetPacketInformation(ServerPacketHeader serverPacketHeader)
        {
            PacketInformation packetInformation = null;
            try
            {
                packetInformation = packetParser.GetPacketInformation(serverPacketHeader);
            }
            catch
            {
                lock (Logger.LastLogs)
                {
                    foreach (String lastLogs in Logger.LastLogs)
                        Console.WriteLine(lastLogs);
                }
            }
            return packetInformation;
        }

        private void ProcessReceivedData()
        {
            ServerPacketHeader serverPacketHeader;
            PacketInformation packetInformation;

            RemoveDecryptionTail();
            if (decryptedData.Count <= 0)
                return;

            serverPacketHeader = (ServerPacketHeader)decryptedData.Peek();
            packetInformation = GetPacketInformation(serverPacketHeader);

            while (decryptedData.Count >= packetInformation.Size)
            {
                byte[] rawData = decryptedData.Peek(packetInformation.Size);

                ServerPacket packet = packetParser.CreatePacket(rawData) as ServerPacket;
                UInt16 dynamicSize = GetDynamicSize(packet, packetInformation);
                if (decryptedData.Count < dynamicSize)
                    break;
                Logger.LogDebug("Received: " + packet.PacketHeader, rawData);
                
                decryptedData.Skip(packetInformation.Size);
                packet.Received(this);

                RemoveDecryptionTail();
                if (decryptedData.Count == 0)
                    break;
                else
                {
                    serverPacketHeader = (ServerPacketHeader)decryptedData.Peek();
                    packetInformation = GetPacketInformation(serverPacketHeader);
                }
            }
        }

    }
}
