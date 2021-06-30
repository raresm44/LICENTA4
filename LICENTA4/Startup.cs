using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LICENTA4.Startup))]
namespace LICENTA4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
