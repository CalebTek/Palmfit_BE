﻿using Microsoft.AspNetCore.Identity;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IAuthRepository
    {
        string GenerateJwtToken(AppUser user);
        
         
        Task<IdentityResult> CreatePermissionAsync(string name);
        Task<IEnumerable<AppUserPermission>> GetAllPermissionsAsync(); 
        Task<IEnumerable<AppUserPermission>> GetPermissionsByRoleNameAsync(string roleId);
        Task AssignPermissionToRoleAsync(string roleName, string permissionName);
        Task<IdentityResult> RemovePermissionFromRoleAsync(string roleId, string permissionId);
    }
}
