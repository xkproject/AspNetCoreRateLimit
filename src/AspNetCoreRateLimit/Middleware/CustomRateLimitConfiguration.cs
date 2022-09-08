using AspNetCoreRateLimit;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreRateLimit.Middleware
{
    public class CustomRateLimitConfiguration : RateLimitConfiguration
    {
        public CustomRateLimitConfiguration(IOptions<IpRateLimitOptions> ipOptions, IOptions<ClientRateLimitOptions> clientOptions) : base(ipOptions, clientOptions)
        {
        }

        public override void RegisterResolvers()
        {
            base.RegisterResolvers();
            ClientResolvers.Add(new ClientUserResolveContributor());
        }
    }
}
