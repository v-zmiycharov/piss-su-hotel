using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PissHotel.Startup))]
namespace PissHotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
