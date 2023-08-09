using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
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
            var appUser = _dbContext.Users.FirstOrDefault(user => user.ReferralCode == referralCode);

            if (appUser == null)
            {
                return new List<InviteDto>();
            }

            var invites = await _dbContext.Invites
                .Where(user => user.AppUserId == appUser.Id)
                .Select(invite => new InviteDto
                {
                    Name = invite.Name,
                    Email = invite.Email,
                    Phone = invite.Phone,
                    Date = invite.Date,
                    ReferralCode = invite.AppUser.ReferralCode
                })
                .ToListAsync();

            return invites;
        }

    }
}
