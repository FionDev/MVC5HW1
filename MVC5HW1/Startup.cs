using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5HW1.Startup))]
namespace MVC5HW1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
