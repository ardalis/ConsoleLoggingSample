using NLog;

namespace LoggingConsole
{
    public class Greeting
    {
        private readonly CustomLogger _logger = (CustomLogger)LogManager.GetCurrentClassLogger(typeof(CustomLogger));

        public string SayHello(string name)
        {
            _logger.SetCustomerId(123);
            _logger.Info("SayHello started.");
            return $"Hello {name}!";
        }
    }
}