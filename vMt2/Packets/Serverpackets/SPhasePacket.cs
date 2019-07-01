using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using vMt2.Encryption;
using vMt2.Enums;
using System.Linq;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacketAttribute(ServerPacketHeader.HEADER_GC_PHASE)]
    class SPhasePacket : ServerPacket
    {
        public Phase Phase { get; set; }

        public override void Received(VirtualClient virtualClient)
        {
            virtualClient.currentPhase = this.Phase;
            if (this.Phase == Phase.AUTH)
                Received_PhaseAuth(virtualClient);
            else if (this.Phase == Phase.Login)
                Received_PhaseLogin(virtualClient);
            else if (this.Phase == Phase.Game)
                Received_PhaseGame(virtualClient);
            else if (this.Phase == Phase.SENTRY)
                Received_PhaseSentry(virtualClient);
            else if (this.Phase == Phase.Select)
                Received_PhaseSelect(virtualClient);
        }

        private void Received_PhaseSentry(VirtualClient virtualClient)
        {
            CSentrySendPacket packet = new CSentrySendPacket()
            {
                Mac = "00::00::20::00::00::02",
                Guid = "445cd91f-7ae3-acab-9ffa-51b9dc5bfabb",
                CpuId = "288BBBFF0F100BA0",
                HddMod = "SAMSUNGSUPERFASTFUCKYOU",
                HddSer = "RS032GYJAB6969SHIT0845",
                DeviceName = "DESKTOP"
            };
            virtualClient.SendPacket(packet);
        }

        private void Received_PhaseGame(VirtualClient virtualClient)
        {
            
        }

        private void Received_PhaseLogin(VirtualClient virtualClient)
        {
            if (virtualClient.LoginInformation.LoginKey.HasValue == false)
                throw new Exception("No Login Key available");
            virtualClient.Encryption = true;
            CLogin2Packet packet = new CLogin2Packet
            {
                Username = virtualClient.LoginInformation.Username,
                LoginKey = virtualClient.LoginInformation.LoginKey.Value
            };
            Array.Copy(virtualClient.ClientKey, packet.ClientKey, 4);
            virtualClient.SendPacket(packet);

            byte[] encryptKey = new byte[16];
            Buffer.BlockCopy(virtualClient.ClientKey, 0, encryptKey, 0, 16);
            byte[] key = CryptoUtils.GetKey_20050304Myevan();
            byte[] decryptKey = TinyEncryptionAlgorithm.Encrypt(encryptKey, key);
            virtualClient.SetXteaKey(encryptKey, decryptKey);
        }

        private void Received_PhaseAuth(VirtualClient virtualClient)
        {
            virtualClient.Encryption = true;

            CLogin3Packet packet = new CLogin3Packet()
            {
                Username = virtualClient.LoginInformation.Username,
                Password = virtualClient.LoginInformation.Password,
                HWID = "CSsa/aFvBBQNA+1mkwS41lCvp4VYNBcw4UdoLWRD/1E=",
                Language = "de",
                Timestamp = virtualClient.ClientVersion,
            };
            Array.Copy(virtualClient.ClientKey, packet.ClientKey, 4);

            virtualClient.SendPacket(packet);
        }

        private void Received_PhaseSelect(VirtualClient virtualClient)
        {
        }

    }
}