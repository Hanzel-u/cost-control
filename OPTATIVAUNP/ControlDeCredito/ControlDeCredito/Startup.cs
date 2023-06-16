using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlDeCredito.Startup))]
namespace ControlDeCredito
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
