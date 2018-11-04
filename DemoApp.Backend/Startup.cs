using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoApp.Backend.Startup))]
namespace DemoApp.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
