using Autofac;
using Autofac.Builder;
using StackCafe.Common.AppDomainScanner;

namespace StackCafe.MakeLineMonitor
{
    public static class IoC
    {
        public static IContainer LetThereBeIoC(ContainerBuildOptions containerBuildOptions = ContainerBuildOptions.None)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(AppDomainScanner.MyAssemblies);
            return builder.Build(containerBuildOptions);
        }
    }
}
