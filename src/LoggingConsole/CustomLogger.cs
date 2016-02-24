using NLog;

namespace LoggingConsole
{
    public class CustomLogger : Logger
    {
        public void SetCustomerId(int CustomerId)
        {
            // https://github.com/nlog/NLog/wiki/Mdc-Layout-Renderer
            MappedDiagnosticsContext.Set("CustomerId", CustomerId);
        }
    }
}