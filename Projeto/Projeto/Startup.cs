using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projeto.Startup))]
namespace Projeto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
