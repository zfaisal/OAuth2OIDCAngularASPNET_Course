using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripCompany.IdentityServer.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            Client c1 = new Client
            {
                ClientId = "tripgalleryclientcredentials"
                 , ClientName = "Trip Gallery (Client Credientials)"
                 , Flow = Flows.ClientCredentials
                 , ClientSecrets = new List<Secret>()
                 {
                     new Secret(TripGallery.Constants.TripGalleryClientSecret.Sha256())
                 }
                 ,
                AllowAccessToAllScopes = true
            };


            Client c2 = new Client
            {
                ClientId = "tripgalleryimplicit"
                 ,
                ClientName = "Trip Gallery (Implicit)"
                 ,
                Flow = Flows.Implicit
                 ,
                ClientSecrets = new List<Secret>()
                 {
                     new Secret(TripGallery.Constants.TripGalleryClientSecret.Sha256())
                 }
                 ,
                AllowAccessToAllScopes = true
                ,
                RedirectUris = new List<string>
                {
                    TripGallery.Constants.TripGalleryAngular +"callback.html"
                }
            };

            return new[]
            {
                c1, c2
            };
        }
    }
}