using AirTickets.Auth;
using AirTickets.Auth.Contracts;
using AirTickets.Data;
using AirTickets.Data.Contracts;
using AirTickets.Data.EfRepository;
using AirTickets.DataServices;
using AirTickets.DataServices.Contracts;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AirTickets.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AirTickets.Web.App_Start.NinjectWebCommon), "Stop")]

namespace AirTickets.Web.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static IKernel Kernel
        {
            get;
            private set;
        }

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
        public static IKernel CreateKernel()
        {
            Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(Kernel);
                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAirTicketDbContextSaveChanges>().To<AirTicketEfDbContext>().InRequestScope();

            kernel.Bind<ISignInService>().ToMethod(_ => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());
            kernel.Bind<IUserService>().ToMethod(_ => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());

            kernel.Bind(typeof(IEfDbSetWrapper<>)).To(typeof(EfDbSetWrapper<>));
            kernel.Bind<IFlightService>().To<FlightService>();
            kernel.Bind<IAirlineService>().To<AirlineService>();
        }        
    }
}
