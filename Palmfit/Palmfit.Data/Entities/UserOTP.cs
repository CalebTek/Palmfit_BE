using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Data.Entities
{
    public class UserOTP:BaseEntity
    {
        public string Email { get; set; }
        public int OTP { get; set; }
        public DateTime Expiration { get; set; }
    }
}
