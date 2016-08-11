using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripCompany.IdentityServer.Config
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            InMemoryUser m1 = new InMemoryUser { Username = "Kevin", Password="secret", Subject="wriwoper023424"};
            InMemoryUser m2 = new InMemoryUser { Username = "Sven", Password = "secret", Subject = "jnghjdfdfg567889" };

            List<InMemoryUser> inmemoUsers = new List<InMemoryUser>();
            inmemoUsers.Add(m1);
            inmemoUsers.Add(m2);
            return inmemoUsers;

        }
    }
}