using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MakeUpBoxesStore.Startup))]
namespace MakeUpBoxesStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
