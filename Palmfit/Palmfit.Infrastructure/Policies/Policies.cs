using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Infrastructure.Policies
{
    public static class Policies
    {
        public const string Admin = "Admin";
        public const string SuperAdmin = "SuperAdmin";

        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(Admin)
                .Build();
        }


    }
}
