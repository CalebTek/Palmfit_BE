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
        //props
        private readonly IInviteServices _inviteServices;

        //ctor
        public InviteController(IInviteServices inviteServices)
        {
            _inviteServices = inviteServices;
        }



        [HttpDelete("Delete-Invite/{id}")]
        public async Task<IActionResult> DeleteInvite(string id)
        {
            if (id == null)
                return BadRequest(ApiResponse.Failed("Invalid Id"));
            
            var result = await _inviteServices.Deleteinvite(id);

            if (!result)
                return NotFound(ApiResponse.Failed(result, "Invite not found"));

            return Ok(ApiResponse.Success(result));
        }
    }
}
