using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartyApp.Startup))]
namespace PartyApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
