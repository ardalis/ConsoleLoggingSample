using NLog;

namespace LoggingConsole
{
    public class Greeting
    {
        private readonly MemLogger _logger = (MemLogger)LogManager.GetCurrentClassLogger(typeof(MemLogger));

        public string SayHello(string name)
        {
            _logger.SetCustomerId(123);
            _logger.Info("SayHello started.");
            return $"Hello {name}!";
        }
    }
}