using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACMWeb.Startup))]
namespace ACMWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
