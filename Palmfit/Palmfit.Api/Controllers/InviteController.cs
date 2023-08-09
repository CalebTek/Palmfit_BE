using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InviteController : ControllerBase
    {
        private readonly IInviteRepository _inviteRepository;
        //props
        private readonly IInviteServices _inviteServices;

        public InviteController(IInviteRepository inviteRepository)
        //ctor
        public InviteController(IInviteServices inviteServices)
        {   
            _inviteRepository = inviteRepository;
            _inviteServices = inviteServices;
        }

        [HttpGet("{userId}/api-to-invites-of-user")]
        public async Task<IActionResult> GetInvitesByUserId(string userId)


        [HttpDelete("Delete-Invite/{id}")]
        public async Task<IActionResult> DeleteInvite(string id)
        {
            try
            {
                var inviteDTOs = await _inviteRepository.GetInvitesByUserId(userId);
                return Ok(ApiResponse.Success(inviteDTOs));
            }
            catch (Exception)
            {
                return NotFound(ApiResponse.Failed("Invite does not exist."));
            }
            if (id == null)
                return BadRequest(ApiResponse.Failed("Invalid Id"));
            
            var result = await _inviteServices.Deleteinvite(id);

            if (!result)
                return NotFound(ApiResponse.Failed(result, "Invite not found"));

            return Ok(ApiResponse.Success(result));
        }
    }
}
