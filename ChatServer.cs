using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OSPract3
{
    public class ChatServer : IChatMember
    {
        private volatile bool _running = true;
        private List<TcpClient> _clients = new();

        public ChatServer()
        {
            new Thread(StartServer).Start();
        }

        public void Send(string message)
        {
            Logger.Log(ChatManager.WrapMessage(message));
            SendExcept(message, null);
        }

        private async void SendExcept(string message, TcpClient? clientToExcept)
        {
            foreach (TcpClient client in _clients)
            {
                if (client == clientToExcept)
                    continue;
                await client.GetStream().WriteAsync(Encoding.UTF8.GetBytes(message));
            }
        }

        public void Quit()
        {
            _running = false;
        }

        private async void StartServer()
        {
            var tcpListener = new TcpListener(IPAddress.Parse(ChatManager.Ip), ChatManager.Port);
            try
            {
                tcpListener.Start();    // запускаем сервер
                Logger.Log("Сервер запущен. Ожидание подключений... ");

                while (_running)
                {
                    // получаем подключение в виде TcpClient
                    var tcpClient = await tcpListener.AcceptTcpClientAsync();
                    Logger.Log($"Входящее подключение: {tcpClient.Client.RemoteEndPoint}");
                    _clients.Add(tcpClient);
                    WorkWithClient(tcpClient);
                }
            }
            finally
            {
                tcpListener.Stop(); // останавливаем сервер
            }
        }

        private async void WorkWithClient(TcpClient client)
        {
            try
            {
                var stream = client.GetStream();
                while (client.Connected)
                {
                    var responseData = new byte[512];
                    var response = new StringBuilder();
                    int bytes;
                    do
                    {
                        bytes = await stream.ReadAsync(responseData);
                        response.Append(Encoding.UTF8.GetString(responseData, 0, bytes));
                    }
                    while (bytes > 0 && stream.DataAvailable);

                    string message = response.ToString();
                    if (message.Length > 0)
                    {
                        Logger.Log(ChatManager.WrapMessage(message));
                        SendExcept(message, client);
                    }
                }
            }
            catch (IOException) { }
        }
    }
}
