using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OSPract3
{
    public class ChatClient : IChatMember
    {
        private TcpClient _tcpClient;

        public ChatClient(TcpClient client)
        {
            _tcpClient = client;
            new Thread(ListenToServer).Start();
        }

        public async void Send(string message)
        {
            var requestData = Encoding.UTF8.GetBytes(message);
            await _tcpClient.GetStream().WriteAsync(requestData);
            Logger.Log(ChatManager.WrapMessage(message));
        }

        public void Quit()
        {
            _tcpClient.Dispose();
        }

        private async void ListenToServer()
        {
            try
            {
                var stream = _tcpClient.GetStream();
                while (_tcpClient.Connected)
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

                    if (response.ToString().Length > 0)
                        Logger.Log(ChatManager.WrapMessage(response.ToString()));
                }
            }
            catch (IOException) { }
        }
    }
}
