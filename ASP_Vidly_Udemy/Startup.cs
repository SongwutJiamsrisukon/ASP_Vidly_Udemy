using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP_Vidly_Udemy.Startup))]
namespace ASP_Vidly_Udemy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //
            ConfigureAuth(app);
        }
    }
}
