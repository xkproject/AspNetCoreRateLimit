using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreRateLimit
{
    public class ClientUserResolveContributor : IClientResolveContributor
    {
        public Task<string> ResolveClientAsync(HttpContext httpContext)
        {
            //TO-DO Get user from httpContext and then get ClientId
            throw new NotImplementedException();
        }
    }
}
