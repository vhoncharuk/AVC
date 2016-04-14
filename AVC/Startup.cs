using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AVC.Startup))]
namespace AVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
