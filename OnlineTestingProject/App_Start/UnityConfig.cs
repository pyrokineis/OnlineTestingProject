using System.Web.Mvc;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Repositories;
using OnlineTestingProject.Services;
using Unity;
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
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}