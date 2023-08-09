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

        [HttpPost("remove-funds")]
        public async Task<IActionResult> RemoveFunds(string walletId, decimal amount)
        {

            var removedFunds = await _wallet.RemoveFundFromWallet(walletId, amount);

            if(!removedFunds.Any())
            {
                return BadRequest(ApiResponse.Failed("Failed to perform transaction"));
            }
            return Ok(ApiResponse.Success("Funds successfully removed"));
            
        }
    }
}
