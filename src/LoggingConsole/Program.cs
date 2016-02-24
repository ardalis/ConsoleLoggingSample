using System;
using System.Data.SqlClient;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.Targets;

namespace LoggingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureLogging();
            var _logger = (MemLogger)LogManager.GetCurrentClassLogger(typeof(MemLogger));
            _logger.Info("Application started");


        var greeting = new Greeting();

            Console.WriteLine(greeting.SayHello("Steve"));

            Console.ReadLine();
            _logger.Info("Application exiting.");
        }

        private static void ConfigureLogging()
        {
            var logConfig = new LoggingConfiguration();

            // add targets
            var consoleTarget = new ColoredConsoleTarget();
            consoleTarget.Layout = consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message} ${mdc:item=CustomerId}";
            logConfig.AddTarget("console", consoleTarget);

            var dbTarget = new DatabaseTarget();
            dbTarget.ConnectionStringName = "NLog";
            dbTarget.CommandText = @"
INSERT INTO [dbo].[NLog]
           ([MachineName]
           ,[SiteName]
           ,[Logged]
           ,[Level]
           ,[UserName]
           ,[Message]
           ,[Logger]
           ,[Properties]
           ,[ServerName]
           ,[Port]
           ,[Url]
           ,[Https]
           ,[ServerAddress]
           ,[RemoteAddress]
           ,[Callsite]
           ,[CustomerId]
           ,[Exception])
     VALUES (
            @machineName,
            @siteName,
            @logged,
            @level,
            @userName,
            @message,
            @logger,
            @properties,
            @serverName,
            @port,
            @url,
            @https,
            @serverAddress,
            @remoteAddress,
            @callSite,
            @CustomerId,
            @exception
            )
";
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@MachineName", "${machinename}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@SiteName", "n/a"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Logged", "${date}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Level", "${level}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Username", "${identity}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Message", "${message}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Logger", "${logger}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Properties", "${all-event-properties:separator=|}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@ServerName", "n/a"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Port", "n/a"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Url", "n/a"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Https", "0"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@ServerAddress", "n/a"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@RemoteAddress", "n/a"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@CallSite", "${callsite}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@CustomerId", "${mdc:item=CustomerId}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Exception", "${exception:tostring"));


            // add rules
            var rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            logConfig.LoggingRules.Add(rule1);

            var rule2 = new LoggingRule("*", LogLevel.Debug, dbTarget);
            logConfig.LoggingRules.Add(rule2);

            LogManager.Configuration = logConfig;
        }
    }
}
