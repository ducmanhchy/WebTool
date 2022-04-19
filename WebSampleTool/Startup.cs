using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebSampleTool.Startup))]
namespace WebSampleTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
