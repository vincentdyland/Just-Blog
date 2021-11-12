using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FA.JustBlogg.Startup))]
namespace FA.JustBlogg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
