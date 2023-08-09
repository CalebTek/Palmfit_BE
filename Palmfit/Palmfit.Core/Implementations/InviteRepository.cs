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
    public class InviteRepository : IInviteServices
    public class InviteRepository : IInviteRepository
    {
        //props
        private readonly PalmfitDbContext _dbContext;

        //ctor
        public InviteRepository(PalmfitDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //delete an invite
        public async Task<bool> Deleteinvite(string id)
        public async Task<List<InviteDto>> GetInvitesByUserId(string userId)
        {
            var getData = await _dbContext.Invites.FirstOrDefaultAsync(x => x.Id == id);

            if (getData == null) return false;

            getData.IsDeleted = true;   
            var result = _dbContext.SaveChanges();
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

            if (result > 0) return true;
            return false;
            return invites;

        }
        
    }
}
