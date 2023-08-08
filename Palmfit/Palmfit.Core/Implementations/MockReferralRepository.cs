using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class MockReferralRepository : IReferralRepository
    {
        private readonly List<Invite> _invites;
        private readonly List<AppUser> _appUsers;

        public MockReferralRepository()
        {
            _appUsers = new List<AppUser>
{
    new AppUser
    {
        Id = "1",
        ReferralCode = "ABC123", // Assign a referral code
        Referrals = new List<Referral> // Initialize Referrals collection
        {
            new Referral
            {
                Id = "1",
                ReferralCode = "XYZ789" // Assign a referral code
            }
        },
        Invities = new List<Invite>
        {
            new Invite
            {
                Id = "1",
                Name = "John Doe",
                Email = "john@example.com",
                Phone = "1234567890",
                Date = DateTime.UtcNow
            }
        }
    }
};

            _invites = _appUsers.SelectMany(u => u.Invities).ToList();
        }


        public async Task<IEnumerable<InviteDto>> GetInvitesByReferralCodeAsync(string referralCode)
        {
            var invites = _invites
                .Where(invite => invite.AppUser.Referrals.Any(r => r.ReferralCode == referralCode))
                .Select(invite => new InviteDto
                {
                    Name = invite.Name,
                    Email = invite.Email,
                    Phone = invite.Phone,
                    Date = invite.Date,
                    ReferralCode = referralCode
                })
                .ToList();

            return invites;
        }

    }


}






