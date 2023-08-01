using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

       
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IAuthRepository authRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _authRepo = authRepo;
        }





        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>("Invalid request. Please provide a valid email and password."));
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(login.Email);

                if (user == null)
                {
                    return NotFound(new ApiResponse<string>("User not found. Please check your email and try again."));
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, lockoutOnFailure: false);

                if (!result.Succeeded)
                {
                    return Unauthorized(new ApiResponse<string>("Invalid credentials. Please check your email or password and try again."));
                }
                else
                {
                    var token = _authRepo.GenerateJwtToken(user);

                    // Returning the token in the response headers
                    Response.Headers.Add("Authorization", "Bearer " + token);

                    return Ok(new ApiResponse<string>("Login successful."));

                }
            }
        }

     

            // Endpoint to create a new role
            [HttpPost("create-role")]
            public async Task<IActionResult> CreateRole(AppUserRole role)
            {
                var result = await _authRepo.CreateRoleAsync(role);
                if (result.Succeeded)
                {
                    return Ok("Role created successfully.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
         


            // Endpoint to update an existing role
            [HttpPut("update-role")]
            public async Task<IActionResult> UpdateRole(AppUserRole role)
            {
                var result = await _authRepo.UpdateRoleAsync(role);
                if (result.Succeeded)
                {
                    return Ok("Role updated successfully.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }



            // Endpoint to delete a role by role ID
            [HttpDelete("delete-role/{roleId}")]
            public async Task<IActionResult> DeleteRole(string roleId)
            {
                var result = await _authRepo.DeleteRoleAsync(roleId);
                if (result.Succeeded)
                {
                    return Ok("Role deleted successfully.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }



            // Endpoint to get all permissions
            [HttpGet("get-all-permissions")]
            public async Task<IActionResult> GetAllPermissions()
            {
                var permissions = await _authRepo.GetAllPermissionsAsync();
                return Ok(permissions);
            }


            // Endpoint to get permissions by role ID
            [HttpGet("get-permissions-by-role/{roleId}")]
            public async Task<IActionResult> GetPermissionsByRoleId(string roleId)
            {
                var permissions = await _authRepo.GetPermissionsByRoleIdAsync(roleId);
                return Ok(permissions);
            }


            // Endpoint to assign a permission to a role
            [HttpPost("assign-permission")]
            public async Task<IActionResult> AssignPermissionToRole(string roleId, string permissionId)
            {
                var result = await _authRepo.AddPermissionToRoleAsync(roleId, permissionId);
                if (result.Succeeded)
                {
                    return Ok("Permission assigned to role successfully.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }


            // Endpoint to remove a permission from a role
            [HttpDelete("remove-permission")]
            public async Task<IActionResult> RemovePermissionFromRole(string roleId, string permissionId)
            {
                var result = await _authRepo.RemovePermissionFromRoleAsync(roleId, permissionId);
                if (result.Succeeded)
                {
                    return Ok("Permission removed from role successfully.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

        }
    }


