using System;

namespace LoggingConsole
{
    public class Application : LoggedClass
    {
        private readonly Greeting _greeting;

        public Application(Greeting greeting)
        {
            _greeting = greeting;
        }

        public void Run()
        {
            Logger.Info("Application started.");
            Console.WriteLine(_greeting.SayHello("Steve"));
            Logger.Info("Application exiting");
        }
    }
}