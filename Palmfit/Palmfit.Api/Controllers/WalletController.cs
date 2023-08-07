using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletRepository _wallet;

        public WalletController(IWalletRepository wallet)
        {
            _wallet = wallet;
        }
        [HttpGet("{appUserId}")]
        public async Task<ActionResult<Wallet>> GetWallet(string appUserId)
        {
            try
            {
                var wallet = await _wallet.GetWalletByUserIdAsync(appUserId);

                if (wallet == null)
                {
                    return NotFound(ApiResponse.Failed("Wallet not found."));
                }

                return Ok(ApiResponse.Success(wallet));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ApiResponse.Failed(ex.ToString()));//"An error occurred while processing your request."
            }
        }
    }
}
