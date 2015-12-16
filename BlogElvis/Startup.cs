using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogElvis.Startup))]
namespace BlogElvis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
