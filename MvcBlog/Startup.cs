using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcBlog.Startup))]
namespace MvcBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
