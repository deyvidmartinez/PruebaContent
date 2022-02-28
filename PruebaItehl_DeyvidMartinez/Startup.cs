using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PruebaItehl_DeyvidMartinez.Startup))]
namespace PruebaItehl_DeyvidMartinez
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
