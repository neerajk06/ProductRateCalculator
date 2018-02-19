using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RateCalculatorClient.Startup))]
namespace RateCalculatorClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
