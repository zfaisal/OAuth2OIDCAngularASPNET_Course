using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TripCompany.IdentityServer.Startup))]

namespace TripCompany.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
