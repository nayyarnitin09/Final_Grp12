using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectTeam12_Latest.Startup))]
namespace ProjectTeam12_Latest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
