using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2
{
    public enum LogLevel
    {
        None,
        Debug,
        Info,
        Warnning,
        Error
    }

    public class Logger
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Info;

        public LinkedList<String> LastLogs { get; set; } = new LinkedList<string>();

        private void outputLine(String log, LogLevel level)
        {
            lock (LastLogs)
            {
                if (LastLogs.Count > 300)
                {
                    LinkedListNode<String> first = LastLogs.First;
                    if (first != null)
                        LastLogs.Remove(first);
                }
                LastLogs.AddLast(log);
            }
            if ((int)level >= (int)LogLevel)
                Console.WriteLine(log);
        }

        private void Log(String logtext, LogLevel logLevel, byte[] bytes = null)
        {
            outputLine(logtext, logLevel);
            if (bytes == null)
                return;
            for (int i = 0; i < (bytes.Length / 16); i++)
            {
                Span<byte> currentLine = new Span<byte>(bytes, i * 16, 16);
                LogLine(currentLine, logLevel);
            }

            int rest = bytes.Length % 16;
            Span<byte> endLine = new Span<byte>(bytes, bytes.Length - rest, rest);
            LogLine(endLine, logLevel);
            outputLine("", logLevel);
        }

        public void LogDebug(String logtext, byte[] bytes = null)
        {
            Log(logtext, LogLevel.Debug, bytes);
        }

        public void LogInfo(String logtext, byte[] bytes = null)
        {
            if ((int)LogLevel.Info >= (int)LogLevel)
                Log(logtext, LogLevel.Info, bytes);
        }


        private void LogLine(Span<byte> input, LogLevel level)
        {
            byte[] bytes = input.ToArray();
            String byteString = BitConverter.ToString(bytes).Replace("-", " ");
            while (byteString.Length < 47)
                byteString += " ";

            byteString += "    ";
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] < 0x20 || bytes[i] > 0x7E)
                    bytes[i] = 0x2E;
            }
            byteString += Encoding.UTF8.GetString(bytes);

            outputLine(byteString, level);
        }

    }
}
