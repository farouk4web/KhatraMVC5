using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Khatra.Startup))]
namespace Khatra
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
