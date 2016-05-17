using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimusFlex.Web.Startup))]
namespace PrimusFlex.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
