using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class ReferralRepository : IReferralRepository
    {
        private readonly PalmfitDbContext _dbContext;
        public ReferralRepository(PalmfitDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<InviteDto>> GetInvitesByReferralCodeAsync(string referralCode)
        {
            var invites = await _dbContext.Invites
                .Where(invite => invite.AppUser.Referrals.Any(r => r.ReferralCode == referralCode))
                .Select(invite => new InviteDto
                {
                    Name = invite.Name,
                    Email = invite.Email,
                    Phone = invite.Phone,
                    Date = invite.Date,
                    ReferralCode = referralCode
                })
                .ToListAsync();

            return invites;
        }

    }
}
