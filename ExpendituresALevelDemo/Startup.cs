using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExpendituresALevelDemo.Startup))]
namespace ExpendituresALevelDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
