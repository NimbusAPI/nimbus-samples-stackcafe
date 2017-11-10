using Autofac;
using ConfigInjector.Configuration;

namespace StackCafe.Common.Configuration.AutofacModules
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            ConfigurationConfigurator.RegisterConfigurationSettings()
                .FromAssemblies(AppDomainScanner.AppDomainScanner.MyAssemblies)
                .RegisterWithContainer(configSetting => builder.RegisterInstance(configSetting)
                    .AsSelf()
                    .SingleInstance())
                .ExcludeSettingKeys(
                    "webpages:Version",
                    "webpages:Enabled",
                    "ClientValidationEnabled",
                    "UnobtrusiveJavaScriptEnabled")
                .DoYourThing();
        }
    }
}