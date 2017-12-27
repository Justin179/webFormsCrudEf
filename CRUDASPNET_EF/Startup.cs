using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDASPNET_EF.Startup))]
namespace CRUDASPNET_EF
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
