namespace LoggingConsole
{
    public class Greeting : LoggedClass
    {
        public string SayHello(string name)
        {
            Logger.Info("{0} started.", nameof(SayHello));
            return $"Hello2 {name}";
        }
    }
}