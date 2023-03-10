using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wed_BisSchool.Startup))]
namespace Wed_BisSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
