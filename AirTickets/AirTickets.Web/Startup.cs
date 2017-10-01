using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirTickets.Web.Startup))]
namespace AirTickets.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
