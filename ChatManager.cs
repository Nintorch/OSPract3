using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OSPract3
{
    public static class ChatManager
    {
        public static async Task<IChatMember> Connect()
        {
            TcpClient tcpClient = new();
            try
            {
                await tcpClient.ConnectAsync(
                    ConfigurationManager.AppSettings.Get("ip") ?? "",
                    int.Parse(ConfigurationManager.AppSettings.Get("port") ?? "0")
                    );
                if (tcpClient.Connected)
                    return new ChatClient(tcpClient);
                else
                    throw new Exception("Client not connected");
            }
            catch (SocketException)
            {
                return new ChatServer();
            }
        }

        public static string WrapMessage(string message)
            => $"Message ({DateTime.Now.ToShortDateString()} - {DateTime.Now.ToLongTimeString()}): {message}";
    }
}
