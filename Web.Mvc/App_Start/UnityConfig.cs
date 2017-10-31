using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Core.Base.Interface.Repository;
using Infra.Data.Repository;
using Core.Base.Interface.Service;
using Core.Base.Service;
using Infra.Data.Context;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Web.Mvc.Controllers;

namespace Web.Mvc
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<IFriendService, FriendService>();
            container.RegisterType<IGameService, GameService>();

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}