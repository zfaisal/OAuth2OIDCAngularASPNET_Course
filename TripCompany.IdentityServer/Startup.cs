using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using TripCompany.IdentityServer.Config;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Security;

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
            //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            return new X509Certificate2(string.Format(@"{0}\Certificate\zaki1.pfx", AppDomain.CurrentDomain.BaseDirectory), "password");
        }
    }
}
