using SharedPacketLib;
using System;
using System.Net.Sockets;

namespace ConnectionManager
{
    public class ConnectionInformation : IDisposable
    {
        private readonly Socket dataSocket;
        private readonly string ip;
        private readonly int connectionID;
        private bool isConnected;
        private readonly byte[] buffer;
        private readonly AsyncCallback sendCallback;

        public IDataParser parser { get; set; }

        public event ConnectionInformation.ConnectionChange connectionClose;

        public ConnectionInformation(Socket dataStream, int connectionID, IDataParser parser, string ip)
        {
            this.parser = parser;
            this.buffer = new byte[GameSocketManagerStatics.BUFFER_SIZE];

            this.dataSocket = dataStream;
            this.dataSocket.SendTimeout = 1000 * 30;
            this.dataSocket.ReceiveTimeout = 1000 * 30;
            this.dataSocket.SendBufferSize = GameSocketManagerStatics.BUFFER_SIZE;
            this.dataSocket.ReceiveBufferSize = GameSocketManagerStatics.BUFFER_SIZE;

            sendCallback = sentData;

            this.ip = ip;
            this.connectionID = connectionID;
        }

        public void startPacketProcessing()
        {
            if (this.isConnected)
                return;
            this.isConnected = true;
            try
            {
                this.dataSocket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, this.incomingDataPacket, (object)this.dataSocket);
            }
            catch
            {
                this.disconnect();
            }
        }

        public string getIp()
        {
            return this.ip;
        }

        public int getConnectionID()
        {
            return this.connectionID;
        }

        public void disconnect()
        {
            try
            {
                if (this.isConnected)
                {
                    this.isConnected = false;
                    if (this.dataSocket != null)
                    {
                        try
                        {

                            if (this.dataSocket.Connected)
                            {
                                this.dataSocket.Shutdown(SocketShutdown.Both);
                                this.dataSocket.Close();
                            }
                        }
                        catch
                        {
                        }
                        this.dataSocket.Dispose();
                    }
                    if(this.parser != null)
                        this.parser.Dispose();

                    if (this.connectionClose != null)
                        this.connectionClose(this);

                    this.connectionClose = null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Dispose()
        {
            if (this.isConnected)
            {
                this.disconnect();
            }

            GC.SuppressFinalize(this);
        }

        private void incomingDataPacket(IAsyncResult iAr)
        {
            if (!isConnected)
                return;
            int length = 0;
            try
            {
                length = this.dataSocket.EndReceive(iAr);
            }
            catch
            {
                this.disconnect();
                return;
            }

            if (length == 0)
            {
                this.disconnect();
            }
            else
            {
                try
                {
                    //if (length >= GameSocketManagerStatics.BUFFER_SIZE)
                    //{
                        //Console.WriteLine("Reçu Packet taille max du Buffer !");
                    //}
                    //else
                    //{
                        byte[] packet = new byte[length];
                        Array.Copy(this.buffer, packet, length);

                        if (this.parser != null)
                        {
                            this.parser.handlePacketData(packet);
                        }
                    //}
                }
                catch
                {
                    this.disconnect();
                }
                finally
                {
                    try
                    {
                        this.dataSocket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(this.incomingDataPacket), (object)this.dataSocket);
                    }
                    catch
                    {
                        this.disconnect();
                    }
                }
            }
        }

        public void SendData(byte[] packet)
        {
            if (!this.isConnected)
                return;
            try
            {
                this.dataSocket.BeginSend(packet, 0, packet.Length, SocketFlags.None, sendCallback, null);
            }
            catch
            {
                this.disconnect();
            }
        }

        private void sentData(IAsyncResult iAr)
        {
            try
            {
                this.dataSocket.EndSend(iAr);
            }
            catch
            {
                this.disconnect();
            }
        }

        public delegate void ConnectionChange(ConnectionInformation information);
    }
}
