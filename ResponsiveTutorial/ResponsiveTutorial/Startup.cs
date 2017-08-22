using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResponsiveTutorial.Startup))]
namespace ResponsiveTutorial
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
