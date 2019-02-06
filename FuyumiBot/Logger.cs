using System;

namespace FuyumiBot
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            if(message == null)
                throw new ArgumentException("cannot log a null message.");
            Console.WriteLine(message);
        }
    }
}
