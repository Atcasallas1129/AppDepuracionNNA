using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppDepuracionNNA.Startup))]
namespace AppDepuracionNNA
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
