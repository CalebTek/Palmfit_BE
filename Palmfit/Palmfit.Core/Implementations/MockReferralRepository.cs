using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;

namespace Palmfit.Core.Implementations
{
    public class MockReferralRepository : IReferralRepository
    {
        private readonly List<Referral> _referrals;
        private readonly List<Invite> _invites;
        private readonly List<AppUser> _appUsers;

        public MockReferralRepository()
        {
            _referrals = new List<Referral>
            {
                new Referral { Id = "1", ReferralCode = "REF123", AppUserId = "user1" },
                new Referral { Id = "2",ReferralCode = "REF456", AppUserId = "user2"}
            };

            _invites = new List<Invite>
            {
                new Invite { Id = "1", Name = "Invitee 1", Email = "invitee1@example.com", Phone = "1234567890", AppUserId = "user1", Date = DateTime.Now },
                new Invite { Id = "2", Name = "Invitee 2", Email = "invitee2@example.com", Phone = "0123456789", AppUserId = "user1", Date = DateTime.Now},
                new Invite { Id = "2", Name = "Invitee 3", Email = "invitee3@example.com", Phone = "0123456789", AppUserId = "user2", Date = DateTime.Now}
            };

            _appUsers = new List<AppUser>
            {
                new AppUser { Id = "user1", ReferralCode = "REF123", Referrals = _referrals , Invities = _invites},
                new AppUser { Id = "user2", ReferralCode = "REF456", Referrals = _referrals , Invities = _invites}
            };


        }


        public async Task<IEnumerable<InviteDto>> GetInvitesByReferralCodeAsync(string referralCode)
        {
            var appUser = _appUsers.FirstOrDefault(user => user.ReferralCode == referralCode);

            if (appUser == null)
            {
                return new List<InviteDto>();
            }

            var invites = appUser.Invities.Where(user => user.AppUserId == appUser.Id).Select(invite => new InviteDto
            {
                Name = invite.Name,
                Email = invite.Email,
                Phone = invite.Phone,
                Date = invite.Date,
            }).ToList();

            return invites;
        }


        
    }
}






