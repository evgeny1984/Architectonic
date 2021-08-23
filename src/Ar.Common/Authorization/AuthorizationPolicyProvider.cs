using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Sp.Common.Authorization
{
    /// <summary>
    /// Collects all Authorization attributes with "Policy = .."
    /// and generates policies with user claim check.
    /// </summary>
    public static class AuthorizationPolicyCollector
    {

        public static IServiceCollection AddPolicyBasedAuthorization(this IServiceCollection services, Type referenceType)
        {
            var controllerPolicies = CollectControllerAuthorizationPolicies(referenceType).ToList();
            return services.AddAuthorizationCore(opts =>
            {
                controllerPolicies.ForEach(policy =>
                    opts.AddPolicy(policy, p =>
                        p.RequireClaim(CustomClaimTypes.Permission, new string[] { policy })));
            });
        }

        private static IEnumerable<string> CollectControllerAuthorizationPolicies(Type referenceType)
        {
            var policies = referenceType.Assembly.GetTypes()
                             .Where(t => typeof(ControllerBase).IsAssignableFrom(t)).ToList()
                             .SelectMany(controller =>
                                 // get controller auth attribute
                                 controller.GetCustomAttributes<AuthorizeAttribute>()
                                           .Where(a => !string.IsNullOrEmpty(a.Policy))
                                           .Select(a => a.Policy)
                                 // scan public methods for auth attribute
                                 .Union(controller
                                           .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                                           .SelectMany(m => m.GetCustomAttributes<AuthorizeAttribute>())
                                           .Where(a => !string.IsNullOrEmpty(a.Policy))
                                           .Select(a => a.Policy))
                             )
                             .Distinct();
            return policies;
        }
    }
}
