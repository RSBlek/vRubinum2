using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using vMt2.Encryption;
using vMt2.Manager;
using vMt2.Packets;

namespace vMt2
{
    public partial class VirtualClient
    {
        public String ClientVersion { get; set; } = "1558518030";
        public byte[] XTeaEncryptKey { get; private set; } = null;
        public byte[] XTeaDecryptKey { get; private set; } = null;
        public Logger Logger { get; } = new Logger();
        public bool IsIngame { get; internal set; } = false;

        private int sequence = 0;
        internal ServerEndPoint ConnectedServerEndPoint { get; private set; } = ServerEndPoint.None;

        internal UInt32[] ClientKey { get; } = new UInt32[4];
        internal NetworkInformation NetworkInformation { get; } = new NetworkInformation();
        internal Phase currentPhase = Phase.Close;

        private readonly TcpClient tcpClient = new TcpClient();
        private readonly Random random = new Random();
        private readonly byte[] defaultXteaKey;
        public VirtualClient(IPEndPoint authenticationServer, IPEndPoint loginServer, byte[] defaultXteaKey)
        {
            this.Logger.LogLevel = LogLevel.Info;
            this.defaultXteaKey = defaultXteaKey;
            this.SetXteaKey(defaultXteaKey);
            this.NetworkInformation.AuthenticationServer = authenticationServer;
            this.NetworkInformation.LoginServer = loginServer;
            this.ShopManager = new ShopManager(this);
            this.InventoryManager = new InventoryManager(this);
            tcpClient.DataReceived += DataReceived;
            packetParser.Initialize();
        }

        internal void ResetSequence()
        {
            sequence = 0;
        }

        public void SendSequence()
        {
            tcpClient.Send(new byte[] { SequenceTable[sequence++] });
        }

        internal void Connect(ServerEndPoint endPoint)
        {
            IPEndPoint ipEndPoint = null;
            if (endPoint == ServerEndPoint.AuthServer)
                ipEndPoint = NetworkInformation.AuthenticationServer;
            else if (endPoint == ServerEndPoint.LoginServer)
                ipEndPoint = NetworkInformation.LoginServer;

            this.Connect(endPoint, ipEndPoint);
        }

        internal void Connect(ServerEndPoint endPoint, IPEndPoint ipEndPoint)
        {
            ConnectedServerEndPoint = endPoint;
            if (ipEndPoint != null)
                tcpClient.Connect(ipEndPoint);
            else
                throw new ArgumentException();
        }

        public void Disconnect()
        {
            tcpClient.CloseConnection();
        }

        internal void SendPacket(ClientPacket packet)
        {
            byte[] packetData = packetParser.CreateByteData(packet);
            Logger.LogDebug("Sent: " + packet.PacketHeader, packetData);
            if (Encryption == true)
            {
                packetData = TinyEncryptionAlgorithm.Encrypt(packetData, XTeaEncryptKey);
            }
            tcpClient.Send(packetData);
        }

        public void SetXteaKey(byte[] key)
        {
            SetXteaKey(key, key);
        }

        public void SetXteaKey(byte[] encryptKey, byte[] decryptKey)
        {
            this.XTeaEncryptKey = new byte[encryptKey.Length];
            this.XTeaDecryptKey = new byte[decryptKey.Length];
            Array.Copy(encryptKey, this.XTeaEncryptKey, encryptKey.Length);
            Array.Copy(decryptKey, this.XTeaDecryptKey, decryptKey.Length);
        }

    }
}
