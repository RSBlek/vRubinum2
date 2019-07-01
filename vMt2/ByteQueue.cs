using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace vMt2
{
    class ByteQueue
    {
        public Int32 Count { get => buffer.Count; }
        private readonly List<byte> buffer = new List<byte>();

        public void Enqueue(byte[] data)
        {
            buffer.AddRange(data);
        }

        public void Skip(int count)
        {
            buffer.RemoveRange(0, count);
        }

        public byte[] Dequeue(int count)
        {
            byte[] output = buffer.Take(count).ToArray();
            buffer.RemoveRange(0, count);
            return output;
        }

        public byte Peek()
        {
            return Peek(1)[0];
        }

        public byte[] Peek(int count)
        {
            return buffer.Take(count).ToArray();
        }

    }
}
