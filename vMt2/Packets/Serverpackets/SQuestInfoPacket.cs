using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace vMt2.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [GamePacket(ServerPacketHeader.HEADER_GC_QUEST_INFO)]
    class SQuestInfoPacket : ServerPacket
    {
        [DynamicSize]
        public UInt16 Size;
        public UInt16 Index;
        public UInt16 CIndex;
        public byte Flag;

        public override void Received(VirtualClient virtualClient)
        {
            UInt16 packetLength = (UInt16)(Size - Marshal.SizeOf<SQuestInfoPacket>());
            byte[] packetBytes = virtualClient.DequeueReceivedData(packetLength);
            QuestPacketType type = QuestPacketType.QUEST_PACKET_TYPE_NONE;

            if ((Flag & (byte)QuestAttributes.QUEST_SEND_IS_BEGIN) > 0)
            {
                if ((QuestPacketType)virtualClient.DequeueReceivedData(1).First() != 0)
                    type = QuestPacketType.QUEST_PACKET_TYPE_BEGIN;
                else
                    type = QuestPacketType.QUEST_PACKET_TYPE_END;
            }
            else
            {
                type = QuestPacketType.QUEST_PACKET_TYPE_UPDATE;
            }

            if ((Flag & (byte)QuestAttributes.QUEST_SEND_TITLE) > 0)
                virtualClient.DequeueReceivedData(31);

            if ((Flag & (byte)QuestAttributes.QUEST_SEND_CLOCK_NAME) > 0)
                virtualClient.DequeueReceivedData(17);

            if ((Flag & (byte)QuestAttributes.QUEST_SEND_CLOCK_VALUE) > 0)
                virtualClient.DequeueReceivedData(4);

            if ((Flag & (byte)QuestAttributes.QUEST_SEND_COUNTER_NAME) > 0)
                virtualClient.DequeueReceivedData(17);

            if ((Flag & (byte)QuestAttributes.QUEST_SEND_COUNTER_VALUE) > 0)
                virtualClient.DequeueReceivedData(4);

            if ((Flag & (byte)QuestAttributes.QUEST_SEND_ICON_FILE) > 0)
                virtualClient.DequeueReceivedData(25);
        }
    }

    enum QuestAttributes : byte
    {
        QUEST_SEND_IS_BEGIN = 1 << 0,
        QUEST_SEND_TITLE = 1 << 1,
        QUEST_SEND_CLOCK_NAME = 1 << 2,
        QUEST_SEND_CLOCK_VALUE = 1 << 3,
        QUEST_SEND_COUNTER_NAME = 1 << 4,
        QUEST_SEND_COUNTER_VALUE = 1 << 5,
        QUEST_SEND_ICON_FILE = 1 << 6,
    };

    enum QuestPacketType : byte
    {
        QUEST_PACKET_TYPE_NONE,
        QUEST_PACKET_TYPE_BEGIN,
        QUEST_PACKET_TYPE_UPDATE,
        QUEST_PACKET_TYPE_END,
    };
}