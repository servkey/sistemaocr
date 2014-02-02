using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CloudOCR.Startup))]
namespace CloudOCR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
