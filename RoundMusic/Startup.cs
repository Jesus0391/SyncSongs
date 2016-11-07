using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoundMusic.Startup))]
namespace RoundMusic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
