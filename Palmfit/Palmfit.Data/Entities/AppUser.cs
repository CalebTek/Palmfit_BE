using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;

namespace Palmfit.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public bool IsLockedOut { get; set; }
        public DateTime LastOnline { get; set; }
        public bool IsVerified { get; set; }
        public bool IsArchived { get; set; }
        public bool Active { get; set; }
        public string ReferralCode { get; set; }
        public string InviteCode { get; set; }
        public Health Health { get; set; }
        public Setting Setting { get; set; }
        public Wallet Wallet { get; set; }

        public List<Invites> Invities { get; set; }
        public List<Notifications> Notifications { get; set; }
        public List<Reviews> Reviews { get; set; }
        public List<Subscriptions> Subscriptions { get; set; }
        public List<Transactions> Transactions { get; set; }
    }
}