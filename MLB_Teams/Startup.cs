using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MLB_Teams.Startup))]
namespace MLB_Teams
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
