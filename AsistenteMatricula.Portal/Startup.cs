using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsistenteMatricula.Portal.Startup))]
namespace AsistenteMatricula.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
