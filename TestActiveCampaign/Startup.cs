using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestActiveCampaign.Startup))]
namespace TestActiveCampaign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
