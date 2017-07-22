using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Klik.Startup))]
namespace Klik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
