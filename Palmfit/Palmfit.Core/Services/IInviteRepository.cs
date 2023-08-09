using Palmfit.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IInviteRepository
    {
        Task<List<InviteDto>> GetInvitesByUserId(string userId);
        Task<bool> Deleteinvite(string id);
    }
}
