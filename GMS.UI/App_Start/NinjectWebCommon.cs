using GMS.App;
using GMS.App.Interfaces;
using GMS.Domain.Interfaces.Repositories;
using GMS.Domain.Interfaces.Services;
using GMS.Domain.Services;
using GMS.Data.Repositories;
using Ninject;
using Ninject.Syntax;
using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using GMS.App.Services;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GMS.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(GMS.UI.App_Start.NinjectWebCommon), "Stop")]

namespace GMS.UI.App_Start
{

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
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IFriendsAppService>().To<FriendsAppService>();
            kernel.Bind<IGamesAppService>().To<GamesAppService>();
            kernel.Bind<ILoansAppService>().To<LoansAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IFriendsService>().To<FriendsService>();
            kernel.Bind<IGamesService>().To<GamesService>();
            kernel.Bind<ILoansService>().To<LoansService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IFriendsRepository>().To<FriendsRepository>();
            kernel.Bind<IGamesRepository>().To<GamesRepository>();
            kernel.Bind<ILoansRepository>().To<LoansRepository>();
        }        
    }
}
