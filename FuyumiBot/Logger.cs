using System;

namespace FuyumiBot
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            if(message == null)
                return;
            Console.WriteLine(message);
        }
    }
}
