using StructureMap;
using StructureMap.Graph;

namespace LoggingConsole.StructureMap
{
    public class ConsoleRegistry : Registry
    {
        public ConsoleRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
            // requires explicit registration; doesn't follow convention
            //For<CustomLogger>().Use((CustomLogger) LogManager.GetCurrentClassLogger(typeof (CustomLogger)));
            //Policies.SetAllProperties(c => c.OfType<CustomLogger>());
            Policies.Add<AddLoggerPolicy>();
        }
    }
}