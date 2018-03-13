using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using TfrRedo.DataAccess;
using TfrRedo.Services.Interfaces;
using TfrRedo.Services.SearchStations.Queries.JourneyFinder;
using TfrRedo.Services.SearchStations.Queries.stationFinder;
using TfrRedo.ViewModels;
using TfrRedo.WebApi.Queries;

namespace TfrRedo
{
    public class MvcApplication : NinjectHttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                });
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private void RegisterServices(IKernel kernel)
        {
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            kernel.Bind<IStationFinder>().To<StationFinder>();
            kernel.Bind<IIndexPageViewModel>().To<IndexPageViewModel>();
            kernel.Bind<IWebApiStationFinder>().To<WebApiStationFinder>();
            kernel.Bind<IStationFinderResultPageViewModel>().To<StationFinderResultPageViewModel>();
            kernel.Bind<IJourneyfinder>().To<JourneyFinder>();
            kernel.Bind<IWebApiJourneyFinder>().To<WebApiJourneyFinder>();
            kernel.Bind<IJourneyDetailsPageViewModel>().To<JourneyDetailsPageViewModel>();
            kernel.Bind<IDatabaseService>().To<DatabaseService>();
            kernel.Bind<IPreviousJourneysViewModel>().To<PreviousJourneysViewModel>();
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}