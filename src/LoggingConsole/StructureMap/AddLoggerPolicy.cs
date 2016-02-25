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
            var parameter =
                instance.Constructor.GetParameters().FirstOrDefault(p => p.ParameterType == typeof (CustomLogger));
            if (parameter != null)
            {
                var logger = (CustomLogger)LogManager.GetLogger(pluginType.ToString(), typeof(CustomLogger));
                instance.Dependencies.AddForConstructorParameter(parameter, logger);
            } 
        }
    }
}