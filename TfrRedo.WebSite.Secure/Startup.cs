using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TfrRedo.WebSite.Secure.Startup))]
namespace TfrRedo.WebSite.Secure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
