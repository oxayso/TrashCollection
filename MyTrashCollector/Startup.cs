using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTrashCollector.Startup))]
namespace MyTrashCollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
