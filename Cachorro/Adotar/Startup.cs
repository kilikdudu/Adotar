using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Adotar.Startup))]
namespace Adotar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
