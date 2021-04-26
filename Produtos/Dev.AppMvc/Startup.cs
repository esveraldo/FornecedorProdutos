using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dev.AppMvc.Startup))]
namespace Dev.AppMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
