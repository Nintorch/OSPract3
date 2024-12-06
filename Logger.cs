using System.Configuration;

namespace OSPract3
{
    public static class Logger
    {
        public static Label? Label { get; set; }
        private static string? _message;
        private static StreamWriter? _logStream;
        private static bool _useLog = ConfigurationManager.AppSettings.Get("useLog") == "1";

        static Logger()
        {
            if (_useLog)
                _logStream = new StreamWriter(File.Open("Log.txt", FileMode.Append, FileAccess.Write));
            UpdateMessage();
        }

        public static void Close()
        {
            _logStream?.Flush();
            _logStream?.Dispose();
        }

        private static object _lock = new object();

        private static async void UpdateMessage()
        {
            while (true)
            {
                lock (_lock)
                {
                    if (_message != null && Label != null)
                    {
                        Label.Text = _message;
                        _logStream?.Write($"({DateTime.Now}): {_message}\n");
                        _message = null;
                    }
                }
                await Task.Delay(100);
            }
        }

        public static void Log(string message)
        {
            lock (_lock)
            {
                _message = message;
            }
        }
    }
}
