[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TfrRedo.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TfrRedo.App_Start.NinjectWebCommon), "Stop")]

namespace TfrRedo.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using TfrRedo.DataAccess;
    using TfrRedo.Services.Interfaces;
    using TfrRedo.Services.SearchStations.Queries.JourneyFinder;
    using TfrRedo.Services.SearchStations.Queries.stationFinder;
    using TfrRedo.ViewModels;
    using TfrRedo.WebApi.Queries;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Bind<IStationFinder>().To<StationFinder>();
                kernel.Bind<IIndexPageViewModel>().To<IndexPageViewModel>();
                kernel.Bind<iWebApiStationFinder>().To<WebApiStationFinder>();
                kernel.Bind<IStationFinderResultPageViewModel>().To<StationFinderResultPageViewModel>();
                kernel.Bind<IJourneyfinder>().To<JourneyFinder>();
                kernel.Bind<iWebApiJourneyFinder>().To<WebApiJourneyFinder>();
                kernel.Bind<IJourneyDetailsPageViewModel>().To<JourneyDetailsPageViewModel>();
                kernel.Bind<IDatabaseService>().To<DatabaseService>();



                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }
}
