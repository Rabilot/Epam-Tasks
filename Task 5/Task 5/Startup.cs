using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task_5.Startup))]
namespace Task_5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
