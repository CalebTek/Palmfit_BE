using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Implementations;
using Palmfit.Core.Services;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InviteController : ControllerBase
    {
        private readonly IInviteRepository _inviteRepository;

        public InviteController(IInviteRepository inviteRepository)
        {   
            _inviteRepository = inviteRepository;
        }

        [HttpGet("{userId}/api-to-invites-of-user")]
        public async Task<IActionResult> GetInvitesByUserId(string userId)
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
        }

        [HttpGet("{ReferralCode}/get-invites-by-referral-code")]
        public async Task<ActionResult<IEnumerable<InviteDto>>> GetInvitesByReferralCode(string referralCode)
        {
            if (string.IsNullOrWhiteSpace(referralCode))
            {
                return BadRequest(ApiResponse.Failed("Referral code cannot be empty."));
            }

            var invites = await _inviteRepository.GetInvitesByReferralCodeAsync(referralCode);

            return Ok(ApiResponse.Success(invites));
        }
    }
}
