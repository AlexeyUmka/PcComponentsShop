using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PcComponentsShop.UI.Startup))]
namespace PcComponentsShop.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
