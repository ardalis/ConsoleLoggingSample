using System;
using System.Linq;
using NLog;
using StructureMap;
using StructureMap.Pipeline;

namespace LoggingConsole.StructureMap
{
    public class AddLoggerPolicy : ConfiguredInstancePolicy
    {
        protected override void apply(Type pluginType, IConfiguredInstance instance)
        {
            var property = instance.SettableProperties().FirstOrDefault(p => p.Name == "Logger");
            if (property != null)
            {
                var logger = (CustomLogger)LogManager.GetLogger(pluginType.ToString(), typeof(CustomLogger));
                instance.Dependencies.AddForProperty(property, logger);
            }
        }
    }
}