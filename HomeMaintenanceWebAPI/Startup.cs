using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeMaintenanceWebAPI.Startup))]
namespace HomeMaintenanceWebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
