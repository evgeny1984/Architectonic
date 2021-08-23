using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Sp.Common.Authorization
{
    /// <summary>
    /// Take the authentication token of the parent
    /// HttpContext and use it for the current request.
    /// </summary>
    public class AuthTokenDelegateHandler : DelegatingHandler
    {

        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthTokenDelegateHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // get the auth header from parent request
            var authHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (authHeader.Count > 0)
            {
                // set the auth header token to the outgoing request
                request.Headers.Add("Authorization", authHeader.ToArray());
            }
            // Proceed calling the inner handler
            return await base.SendAsync(request, cancellationToken);
        }
    }

}
