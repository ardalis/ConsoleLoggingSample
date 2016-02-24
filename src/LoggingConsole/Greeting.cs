using NLog;

namespace LoggingConsole
{
    public class Greeting
    {
        private readonly CustomLogger _logger = (CustomLogger)LogManager.GetCurrentClassLogger(typeof(CustomLogger));

        public Greeting()
        {
            _logger.SetCustomerId(123);
        }

        public string SayHello(string name)
        {
            _logger.Info("{0} started.", nameof(SayHello));
            return $"Hello {name}!";
        }
    }
}