using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Dtos
{
    public class UserInfo
    {
       string
        public bool? IsLockedOut { get; set; }
        public DateTime? LastOnline { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsArchived { get; set; }
        public bool? Active { get; set; }
        public string? ReferralCode { get; set; }
        public string? InviteCode { get; set; }
        public Health? Health { get; set; }
        public Setting? Setting { get; set; }
        public Wallet? Wallet { get; set; }

    }
}
