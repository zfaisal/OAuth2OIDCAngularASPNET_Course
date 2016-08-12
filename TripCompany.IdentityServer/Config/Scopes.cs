using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripCompany.IdentityServer.Config
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            Scope scope = new Scope
            {
                Name = "gallerymanagement"
                 ,
                DisplayName = "Gallery Management"
                 ,
                Description = "Allow the application to manage galleries on your behalf"
                 ,
                Type = ScopeType.Resource
            };

            return new List<Scope>
            {
                scope
            };
        }
    }
}