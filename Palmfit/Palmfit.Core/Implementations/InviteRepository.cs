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
    public class InviteRepository : IInviteRepository
    {
        private readonly PalmfitDbContext _dbContext;
        public InviteRepository(PalmfitDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<InviteDto>> GetInvitesByUserId(string userId)
        {
            var invites = await _dbContext.Invites
                .Where(invite => invite.AppUserId == userId)
                .Select(invite => new InviteDto
                {
                    Date = invite.Date,
                    Name = invite.Name,
                    Email = invite.Email,
                    Phone = invite.Phone
                })
                .ToListAsync();

            return invites;

        }

        /* < Start ----- Get Invites by Referral Code ---- Start > */
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
                })
                .ToListAsync();

            return invites;
        }

        /* < End ----- Get Invites by Referral Code ---- End > */
    }
}
