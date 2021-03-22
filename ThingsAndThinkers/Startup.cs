using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThingsAndThinkers.Startup))]
namespace ThingsAndThinkers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
