using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndentityVarification.Startup))]
namespace IndentityVarification
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
