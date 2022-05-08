using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Notifications;
using OnlineTestingProject.Controllers;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using OnlineTestingProject.Repositories;
using OnlineTestingProject.Services;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace OnlineTestingProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            
            container.RegisterType<IQuestionService, QuestionService>();
            container.RegisterType<IUnitOfWork, EfUnitOfWork>();
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            container.RegisterType<DbContext, ApplicationDbContext>();
            
            container.RegisterType<DbContext, ApplicationDbContext>(
                new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(
                    o => System.Web.HttpContext.Current.GetOwinContext().Authentication
                )
            );
            // container.RegisterType<AccountController>(
            //     new InjectionConstructor());
            
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}