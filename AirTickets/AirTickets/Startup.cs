using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirTickets.Startup))]
namespace AirTickets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
