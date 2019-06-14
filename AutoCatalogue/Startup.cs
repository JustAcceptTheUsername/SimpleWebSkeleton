using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoCatalogue.Startup))]
namespace AutoCatalogue
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
