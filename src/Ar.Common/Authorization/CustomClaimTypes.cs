using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Models;

namespace Ar.Common.Authorization
{
    public static class CustomClaimTypes
    {
        public const string Permission = "permission";

        public const string PermissionScope = "permissions";

        public static readonly IdentityResource PermissionResource = new IdentityResource(PermissionScope, new[] { Permission });
    }
}
