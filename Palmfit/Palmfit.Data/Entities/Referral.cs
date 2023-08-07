using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Data.Entities
{
    public class Referral : BaseEntity
    {
        public DateTime Date { get; set; }
        public string ReferralCode { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
