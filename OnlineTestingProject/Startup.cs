using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineTestingProject.Startup))]
namespace OnlineTestingProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
