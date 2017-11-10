using Autofac;
using AutofacSerilogIntegration;

namespace StackCafe.Common.Logging.AutofacModules
{
    public class LoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterLogger();
        }
    }
}