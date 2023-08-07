using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InviteController : ControllerBase
    {

        [HttpDelete("Delete-Invite/{id}")]
        public async Task<IActionResult> DeleteInvite(string id)
        {


            return Ok();
        }
    }
}
