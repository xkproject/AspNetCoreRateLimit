using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace AspNetCoreRateLimit
{
    public class ClientUserResolveContributor : IClientResolveContributor
    {

        public Task<string> ResolveClientAsync(HttpContext httpContext)
        {
            //TO-DO Get user from httpContext and then get ClientId
            httpContext.Request.Headers.TryGetValue("Authorization", out var authHeader);
            var tokenType = "Bearer";
            if (authHeader.Count != 0)
            {
                var token = (authHeader.ToList())[0];
                if (token.Contains(tokenType))
                {
                    try
                    {
                        token = token.Substring(7);
                        var readedToken = new JwtSecurityToken(token);
                        var clientId = readedToken.Claims.FirstOrDefault(c => c.Type == "client_id")?.Value?.ToString();
                        return Task.FromResult(clientId);
                    }
                    catch {
                        return Task.FromResult<string>(null);
                    }
                }                
            }
            return Task.FromResult<string>(null);
        }
    }
}
