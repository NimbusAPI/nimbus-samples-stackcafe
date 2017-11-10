using Autofac;
using StackCafe.Waiter.Services;

namespace StackCafe.Waiter.AutofacModules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<OrderDeliveryService>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}