using System;
using NLog;

namespace LoggingConsole
{
    public class Application
    {
        private readonly Greeting _greeting;
        private readonly CustomLogger _logger;

        public Application(Greeting greeting, CustomLogger logger)
        {
            _greeting = greeting;
            _logger = logger;
        }

        public void Run()
        {
            _logger.Info("Application started.");
            Console.WriteLine(_greeting.SayHello("Steve"));
            _logger.Info("Application exiting");
        }
    }
}