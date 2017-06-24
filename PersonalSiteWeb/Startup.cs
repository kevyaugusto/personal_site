using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalSiteWeb.Startup))]
namespace PersonalSiteWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
