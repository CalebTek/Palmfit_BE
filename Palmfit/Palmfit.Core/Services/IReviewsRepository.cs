using Palmfit.Core.Dtos;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IReviewsRepository
    {
        Task<ICollection<ReviewsDto>> GetReviewsByUserId(string userId);
    }
}
