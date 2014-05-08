using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventoryManagement.WebUI.Startup))]
namespace InventoryManagement.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
