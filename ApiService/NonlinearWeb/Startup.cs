using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NonlinearWeb.Startup))]
namespace NonlinearWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
