using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Isaac.Startup))]
namespace Isaac
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
