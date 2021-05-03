using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using Services.AddressService;
using SimpleInjector.Integration.WebApi;
using Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BookMyShow.Controllers;
using Ninject.Activation;

namespace BookMyShow
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AutoMapperConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            /*var container = new Container();
            container.Register<IAddressService, AddressService>();
            container.RegisterSingleton<PetaPoco.Database>(() => new PetaPoco.Database("connString"));
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Register<IUserStore<ApplicationUser>>(
    () => new UserStore<ApplicationUser>());

            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>());
             container.Register<UserManager<ApplicationUser>, ApplicationUserManager>();
            container.Verify();*/
            //GlobalConfiguration.Configuration.DependencyResolver =new SimpleInjectorWebApiDependencyResolver(container);
        }
    }

}
