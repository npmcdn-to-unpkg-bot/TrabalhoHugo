using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Si.Dev.Uniplac.TrabalhoSC.Apresentacao.Web.Startup))]
namespace Si.Dev.Uniplac.TrabalhoSC.Apresentacao.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
