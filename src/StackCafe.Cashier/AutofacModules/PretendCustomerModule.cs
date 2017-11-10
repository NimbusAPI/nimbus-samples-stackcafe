using Autofac;
using StackCafe.Cashier.Services;

namespace StackCafe.Cashier.AutofacModules
{
    public class PretendCustomerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<CustomerOrderGenerator>()
                .AsSelf()
                .SingleInstance()
                .AutoActivate()
                .OnActivated(c => c.Instance.Start());
        }
    }
}