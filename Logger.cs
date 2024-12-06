using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSPract3
{
    public static class Logger
    {
        public static Label? Label { get; set; }
        private static string? _message;
        private static StreamWriter _logStream;

        static Logger()
        {
            _logStream = new StreamWriter(File.Open("Log.txt", FileMode.Append, FileAccess.Write));
            UpdateMessage();
        }

        public static void Close()
        {
            _logStream.Flush();
            _logStream.Dispose();
        }

        private static async void UpdateMessage()
        {
            while (true)
            {
                if (_message != null && Label != null)
                {
                    Label.Text = _message;
                    _logStream.Write($"({DateTime.Now}): {_message}\n");
                    _message = null;
                }
                await Task.Delay(100);
            }
        }

        public static void Log(string message)
        {
            _message = message;
        }
    }
}
