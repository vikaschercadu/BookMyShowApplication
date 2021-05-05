using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;
using Models;
using Owin;
using Services.AddressService;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace BookMyShow
{
    public class SimpleInjectorInitializer
    {
        public static Container Initialize(IAppBuilder app)
        {
            var container = GetInitializeContainer(app);


            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
    new SimpleInjectorWebApiDependencyResolver(container);

            return container;
        }

        public static Container GetInitializeContainer(
                  IAppBuilder app)
        {
            var container = new Container();
            //container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle(); ;
            var config = AutoMapperConfig.Initialize();
            container.RegisterInstance<MapperConfiguration>(config);
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));
            container.Register<IAddressService, AddressService>();
            container.RegisterSingleton<PetaPoco.Database>(() => new PetaPoco.Database("connString"));
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.RegisterInstance<IAppBuilder>(app);
            container.Register<ApplicationUserManager>(Lifestyle.Singleton);
            container.Register<ApplicationDbContext>(
                () => new ApplicationDbContext(),
                Lifestyle.Singleton);
            container.Register<IUserStore<ApplicationUser>>(
                () => new UserStore<ApplicationUser>(
                    container.GetInstance<ApplicationDbContext>()),
                Lifestyle.Singleton);
            container.RegisterInitializer<ApplicationUserManager>(
                manager => InitializeUserManager(manager, app));
            // Setup for ISecureDataFormat
            container.Register<ISecureDataFormat<AuthenticationTicket>,
                SecureDataFormat<AuthenticationTicket>>(Lifestyle.Singleton);
            container.Register<ITextEncoder, Base64UrlTextEncoder>(Lifestyle.Singleton);
            container.Register<IDataSerializer<AuthenticationTicket>,
                TicketSerializer>(Lifestyle.Singleton);
            container.Register<IDataProtector>(
                () => new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider()
                    .Create("ASP.NET Identity"),
                Lifestyle.Singleton);


            return container;
        }

        private static void InitializeUserManager(
            ApplicationUserManager manager, IAppBuilder app)
        {
            manager.UserValidator =
             new UserValidator<ApplicationUser>(manager)
             {
                 AllowOnlyAlphanumericUserNames = false,
                 RequireUniqueEmail = true
             };

            //Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            var dataProtectionProvider =
                 app.GetDataProtectionProvider();

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                 new DataProtectorTokenProvider<ApplicationUser>(
                  dataProtectionProvider.Create("ASP.NET Identity"));
            }
        }
    }
}