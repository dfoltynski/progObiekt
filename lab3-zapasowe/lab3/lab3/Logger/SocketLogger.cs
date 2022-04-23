
using System;
using System.Net;
using System.Net.Sockets;

namespace lab3.Logger
{
    public class SocketLogger : ILogger
    {
        private Socket soc;

        public SocketLogger(string address, int port)
        {
            this.soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            System.Net.IPAddress ipAdd = Dns.GetHostAddresses(address)[0];
            soc.Connect(new IPEndPoint(ipAdd, port));
        }

        public void Dispose()
        {
            soc.Dispose();
        }

        public void Log(params string[] messages)
        {
            soc.Send(System.Text.Encoding.UTF8.GetBytes(String.Join(" ", messages)));
        }
    }
}