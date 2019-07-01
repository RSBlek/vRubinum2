using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using vMt2.Packets;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace vMt2
{
    class PacketParser
    {
        private readonly Dictionary<ServerPacketHeader, PacketInformation> packetInformationDict = new Dictionary<ServerPacketHeader, PacketInformation>();

        public void Initialize()
        {
            List<Type> packetTypes = GetPacketTypes();
            InitializeDictionary(packetTypes);
            SetPacketInformation(packetTypes);
        }

        public byte[] CreateByteData(ClientPacket packet)
        {
            //PacketInformation packetInformation = packetInformationDict[packet.PacketHeader];
            //if (Marshal.SizeOf(packet.GetType()) != packetInformation.Size)
            //    throw new Exception("Packet Size is wrong");
            int size = Marshal.SizeOf(packet.GetType());
            byte[] byteData = new byte[size];
            IntPtr intPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(packet, intPtr, true);
            Marshal.Copy(intPtr, byteData, 0, size);
            Marshal.FreeHGlobal(intPtr);
            return byteData;
        }

        public object CreatePacket(byte[] rawData)
        {
            PacketInformation packetInformation = packetInformationDict[(ServerPacketHeader)rawData[0]];
            if (rawData.Length != packetInformation.Size)
                throw new Exception("Error while marshalling bytes to packet. Byte length is wrong");
            object packet = Activator.CreateInstance(packetInformation.PacketType);
            IntPtr intPtr = Marshal.AllocHGlobal(packetInformation.Size);
            Marshal.Copy(rawData, 0, intPtr, packetInformation.Size);
            packet = Marshal.PtrToStructure(intPtr, packet.GetType());
            Marshal.FreeHGlobal(intPtr);
            return packet;
        }

        public void SetPacketInformation(List<Type> packetTypes)
        {
            foreach(Type packetType in packetTypes)
            {
                IEnumerable<GamePacketAttribute> gamePacketAttributes = packetType.GetCustomAttributes<GamePacketAttribute>();
                foreach(GamePacketAttribute gamePacketAttribute in gamePacketAttributes)
                {
                    int packetSize = Marshal.SizeOf(packetType);
                    packetInformationDict[gamePacketAttribute.PacketHeader].Size = packetSize;
                    packetInformationDict[gamePacketAttribute.PacketHeader].PacketType = packetType;
                    packetInformationDict[gamePacketAttribute.PacketHeader].DynamicSizeField = GetDynamicSizeField(packetType);
                }
            }
        }

        public FieldInfo GetDynamicSizeField(Type packetType)
        {
            foreach(FieldInfo field in packetType.GetFields(BindingFlags.Instance | BindingFlags.Public) )
            {
                DynamicSizeAttribute dynamicSizeAttribute = field.GetCustomAttribute<DynamicSizeAttribute>();
                if (dynamicSizeAttribute != null)
                {
                    if (field.FieldType != typeof(UInt16))
                        throw new Exception("Dynamic size field has to be UInt16");
                    else
                        return field;
                }
            }
            return null;
        }

        public PacketInformation GetPacketInformation(ServerPacketHeader serverPacketHeader)
        {
            if (!packetInformationDict.ContainsKey(serverPacketHeader))
                throw new Exception("Unknown packet recieved");
            return packetInformationDict[serverPacketHeader];
        }

        private void InitializeDictionary(List<Type> packetTypes)
        {
            foreach (Type type in packetTypes)
            {
                IEnumerable<GamePacketAttribute> gamePacketAttributes = type.GetCustomAttributes<GamePacketAttribute>();
                foreach(GamePacketAttribute gamePacketAttribute in gamePacketAttributes)
                {
                    packetInformationDict.Add(gamePacketAttribute.PacketHeader, new PacketInformation(gamePacketAttribute.PacketHeader));
                }
            } 
        }


        private List<Type> GetPacketTypes()
        {
            Type[] types = Assembly.GetCallingAssembly().GetTypes();
            List<Type> packetTypes = new List<Type>();
            foreach (Type type in types)
            {
                IEnumerable<GamePacketAttribute> gamePacketAttributes = type.GetCustomAttributes<GamePacketAttribute>();
                if (gamePacketAttributes.Count() > 0)
                {
                    packetTypes.Add(type);
                }
            }
            return packetTypes;
        }


    }
}
