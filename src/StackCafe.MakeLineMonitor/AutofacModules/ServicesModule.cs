using Autofac;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.AutofacModules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<MakeLineService>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
