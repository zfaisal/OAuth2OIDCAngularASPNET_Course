using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using TripCompany.IdentityServer.Config;
using System.Security.Cryptography.X509Certificates;

[assembly: OwinStartup(typeof(TripCompany.IdentityServer.Startup))]

namespace TripCompany.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idsrvApp =>
            {
                var idServerServiceFactory = new IdentityServerServiceFactory()
                                                   .UseInMemoryClients(Clients.Get())
                                                   .UseInMemoryScopes(Scopes.Get())
                                                   .UseInMemoryUsers(Users.Get());
                var options = new IdentityServerOptions
                {
                    Factory = idServerServiceFactory,
                    SiteName = "TripCompany Security Token Service",
                    IssuerUri = TripGallery.Constants.TripGalleryIssuerUri,
                    PublicOrigin = TripGallery.Constants.TripGallerySTSOrigin,
                    SigningCertificate = LoadCertificate()

                };

                idsrvApp.UseIdentityServer(options); 
            });
        }

        private X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(string.Format(@"{0}\Certificate\zaki.pfx", AppDomain.CurrentDomain.BaseDirectory), "password");
        }
    }
}
