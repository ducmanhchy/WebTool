using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSampleTool3.Startup))]
namespace WebSampleTool3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
