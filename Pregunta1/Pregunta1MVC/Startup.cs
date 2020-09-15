using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pregunta1MVC.Startup))]
namespace Pregunta1MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
