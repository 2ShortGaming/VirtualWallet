using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualWallet.Startup))]
namespace VirtualWallet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
