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
    }
}
