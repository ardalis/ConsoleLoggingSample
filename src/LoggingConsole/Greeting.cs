using NLog;

namespace LoggingConsole
{
    public class Greeting
    {
        private readonly CustomLogger _logger;

        public Greeting(CustomLogger logger)
        {
            _logger = logger;
        }

        public string SayHello(string name)
        {
            _logger.Info("{0} started.", nameof(SayHello));
            return $"Hello2 {name}";
        }
    }
}