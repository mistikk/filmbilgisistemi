using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmSistemi.Startup))]
namespace FilmSistemi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
