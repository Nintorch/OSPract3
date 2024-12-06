using System.Net.Sockets;
using System.Net;

namespace OSPract3
{
    public partial class Form1 : Form
    {
        IChatMember? chat;

        public Form1()
        {
            InitializeComponent();
            Logger.Label = Label_Status;
            FormClosed += (_, _) =>
            {
                chat?.Quit();
                Logger.Close();
            };
        }

        private async void Button_Connect_Click(object sender, EventArgs e)
        {
            if (chat != null)
                return;

            Logger.Log("Подключаемся");
            chat = await ChatManager.Connect();
            if (chat is ChatServer)
            {
                Logger.Log("Подключились, мы - сервер");
            }
            else
            {
                Logger.Log("Подключились, мы - клиент");
            }
            Button_Connect.Enabled = false;
        }

        private void Button_Send_Click(object sender, EventArgs e)
        {
            chat?.Send(TextBox_Message.Text);
        }
    }
}
