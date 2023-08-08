using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;

namespace Palmfit.Api.Controllers
{
    public class ReferralController : ControllerBase
    {
        private readonly IReferralRepository _referralRepository;
        public ReferralController(IReferralRepository referralRepository) 
        {
            _referralRepository = referralRepository;
        }

        [HttpGet("get-invites-by-referral-code")]
        public async Task<ActionResult<IEnumerable<InviteDto>>> GetInvitesByReferralCode(string referralCode)
        {
            if (string.IsNullOrWhiteSpace(referralCode))
            {
                return BadRequest(ApiResponse.Failed("Referral code cannot be empty."));
            }

            var invites = await _referralRepository.GetInvitesByReferralCodeAsync(referralCode);

            return Ok(ApiResponse.Success(invites));
        }

    }
}
