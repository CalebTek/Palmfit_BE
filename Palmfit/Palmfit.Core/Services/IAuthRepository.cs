using Microsoft.AspNetCore.Identity;
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
        Task<IdentityResult> CreateRoleAsync(AppUserRole role);
        Task<IdentityResult> UpdateRoleAsync(AppUserRole role);
        Task<IdentityResult> DeleteRoleAsync(string roleId);
        Task<IEnumerable<AppUserPermission>> GetAllPermissionsAsync(); 
        Task<IEnumerable<AppUserPermission>> GetPermissionsByRoleIdAsync(string roleId);
        Task<IdentityResult> AddPermissionToRoleAsync(string roleId, string permissionId);
        Task<IdentityResult> RemovePermissionFromRoleAsync(string roleId, string permissionId);
    }
}
