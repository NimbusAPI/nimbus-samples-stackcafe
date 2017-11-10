using ConfigInjector.QuickAndDirty;
using Serilog;
using Serilog.Core;
using StackCafe.Common.Configuration.Configuration;
using StackCafe.Common.Logging.Configuration;
using StackCafe.Common.Logging.Enrichers;

namespace StackCafe.Common.Logging
{
    public static class DefaultLoggerConfiguration
    {
        public static Logger CreateLogger()
        {
            var logLevelSwitch = new LoggingLevelSwitch();
            var applicationName = DefaultSettingsReader.Get<ApplicationName>();

            var logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(logLevelSwitch)
                .WriteTo.Console()
                .WriteTo.Seq(DefaultSettingsReader.Get<SeqServerUrl>().ToString(), controlLevelSwitch: logLevelSwitch)
                .Enrich.WithProcessId()
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithProperty(nameof(ApplicationName), applicationName)
                .Enrich.With<CorrelationIdEnricher>()
                .CreateLogger();

            logger.Information("Application {ApplicationName} starting up", applicationName);
            return logger;
        }
    }
}
