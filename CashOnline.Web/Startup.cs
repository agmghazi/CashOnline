using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CashOnline.Web.Startup))]
namespace CashOnline.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
