using Palmfit.Core.Dtos;
using Palmfit.Data.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IReferralRepository
    {
        Task<IEnumerable<InviteDto>> GetInvitesByReferralCodeAsync(string referralCode);
    }
}
