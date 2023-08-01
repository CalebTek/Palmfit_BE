using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly PalmfitDbContext _palmfitDbContext; 
        public AuthRepository(IConfiguration configuration, RoleManager<AppUserRole> roleManager, PalmfitDbContext palmfitDbContext)  
        {
            _configuration = configuration;
            _roleManager = roleManager;
            _palmfitDbContext = palmfitDbContext;

        }

        public string GenerateJwtToken(AppUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Set a default expiration in minutes if "AccessTokenExpiration" is missing or not a valid numeric value.
            if (!double.TryParse(jwtSettings["AccessTokenExpiration"], out double accessTokenExpirationMinutes))
            {
                accessTokenExpirationMinutes = 30; // Default expiration of 30 minutes.
            }

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(accessTokenExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<IdentityResult> CreateRoleAsync(AppUserRole role) 
        { 
            return await _roleManager.CreateAsync(role); 
        }

        public async Task<IdentityResult> UpdateRoleAsync(AppUserRole role) 
        { 
            return await _roleManager.UpdateAsync(role); 
        }

        public async Task<IdentityResult> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Role not found." });
            }
            else
            {
                return await _roleManager.DeleteAsync(role);
            }
        }


        public async Task<IEnumerable<AppUserPermission>> GetAllPermissionsAsync() 
        { 
            return await _palmfitDbContext.AppUserPermissions.ToListAsync(); 
        }



        public async Task<IEnumerable<AppUserPermission>> GetPermissionsByRoleIdAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return Enumerable.Empty<AppUserPermission>();
            }
            else
            {
                // Get the claims associated with the role
                var claims = await _roleManager.GetClaimsAsync(role);
                var permissionNames = claims.Where(c => c.Type == "Permission").Select(c => c.Value).ToList();

                // Find the permissions with matching names
                var permissions = _palmfitDbContext.AppUserPermissions.Where(p => permissionNames.Contains(p.Name));
                return permissions;
            }
        }



        public async Task<IdentityResult> AddPermissionToRoleAsync(string roleId, string permissionId)
        {
            // Validate the input GUIDs
            if (!Guid.TryParse(roleId, out var roleIdGuid) || !Guid.TryParse(permissionId, out var permissionIdGuid))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Invalid role or permission ID format." });
            }

            var role = await _roleManager.FindByIdAsync(roleIdGuid.ToString());
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Role not found." });
            }

            var permission = await _palmfitDbContext.AppUserPermissions.FindAsync(permissionIdGuid.ToString());
            if (permission == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Permission not found." });
            }

            // Check if the permission is already associated with the role
            var existingClaim = (await _roleManager.GetClaimsAsync(role)).FirstOrDefault(c => c.Type == "Permission" && c.Value == permission.Name);
            if (existingClaim != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Permission already assigned to role." });
            }

            // Add the new IdentityRoleClaim
            var claim = new Claim("Permission", permission.Name);
            var result = await _roleManager.AddClaimAsync(role, claim);

            // Update the role in the database
            return result;
        }


        public async Task<IdentityResult> RemovePermissionFromRoleAsync(string roleId, string permissionId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Role not found." });
            }

            var permission = await _palmfitDbContext.AppUserPermissions.FindAsync(permissionId);
            if (permission == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Permission not found." });
            }

            // Get the claim associated with the permission and the role
            var claim = (await _roleManager.GetClaimsAsync(role)).FirstOrDefault(c => c.Type == "Permission" && c.Value == permission.Name);
            if (claim != null)
            {
                // Remove the claim from the role
                var result = await _roleManager.RemoveClaimAsync(role, claim);
                if (result.Succeeded)
                {
                    return IdentityResult.Success;
                }
                else
                {
                    // Handle the case where removing the claim fails
                    return IdentityResult.Failed(new IdentityError { Description = "Failed to remove permission from role." });
                }
            }
            return IdentityResult.Failed(new IdentityError { Description = "Permission not assigned to role." });
        }



    }
}
