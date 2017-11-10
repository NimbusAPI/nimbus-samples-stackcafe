using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Serilog;
using StackCafe.Common.Logging;

namespace StackCafe.MakeLineMonitor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        IContainer _container;

        protected void Application_Start()
        {
            Log.Logger = DefaultLoggerConfiguration.CreateLogger();

            _container = IoC.LetThereBeIoC();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            _container.Dispose();
            Log.CloseAndFlush();
        }
    }
}
