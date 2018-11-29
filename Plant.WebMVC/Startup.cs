using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plant.WebMVC.Startup))]
namespace Plant.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
