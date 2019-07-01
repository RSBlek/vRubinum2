using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace vMt2
{
    class TcpClient
    {
        public delegate void TcpReceiveEventHandler(byte[] data);
        public delegate void TcpDisconnectEventHandler();
        public event TcpReceiveEventHandler DataReceived;
        public event TcpDisconnectEventHandler Disconnected;

        private Socket socket;
        private bool isDisposed = true;
        private byte[] receiveBuffer = new byte[65536];
        private Thread receivedDataWorker;

        private BlockingCollection<byte[]> receivedDataQueue = new BlockingCollection<byte[]>();

        public TcpClient()
        {
            receivedDataWorker = new Thread(ProcessData);
            receivedDataWorker.Start();
        }

        public void Connect(IPEndPoint remoteEndPoint)
        {
            if (!isDisposed)
                throw new Exception("Connection is already established");
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.ReceiveBufferSize = 65536;
            socket.Connect(remoteEndPoint);
            isDisposed = false;
            SocketAsyncEventArgs readEventArgs = new SocketAsyncEventArgs();
            readEventArgs.UserToken = this;
            readEventArgs.Completed += Receive;
            StartReceive(readEventArgs);
        }

        public void Send(byte[] data)
        {
            socket.Send(data);
        }

        public void CloseConnection()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            isDisposed = true;
        }

        private void ProcessData()
        {
            while (true)
            {
                byte[] receivedBytes = receivedDataQueue.Take();
                OnDataReceived(receivedBytes);
            }
        }


        private void StartReceive(SocketAsyncEventArgs receiveEventArgs)
        {
            receiveEventArgs.SetBuffer(receiveBuffer);
            try
            {
                if (socket.ReceiveAsync(receiveEventArgs) == false)
                {
                    Task.Run(() => Receive(null, receiveEventArgs));
                }
            }
            catch (Exception)
            {

            }

        }

        private void Receive(Object sender, SocketAsyncEventArgs receiveEventArgs)
        {
            if (receiveEventArgs.BytesTransferred > 0 && receiveEventArgs.SocketError == SocketError.Success)
            {
                byte[] receivedData = new byte[receiveEventArgs.BytesTransferred];
                Array.Copy(this.receiveBuffer, receivedData, receiveEventArgs.BytesTransferred);
                receivedDataQueue.Add(receivedData);
                StartReceive(receiveEventArgs);
            }
            else
            {
                Disconnected?.Invoke();
            }
        }

        private void OnDataReceived(byte[] data)
        {
            DataReceived?.Invoke(data);
        }

    }

}
