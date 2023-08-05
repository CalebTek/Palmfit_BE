using Palmfit.Core.Dtos;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IReviewRepository
    {
        Task<Review> CreateReviewAsync(CreateReviewDto reviewDto);
        Task<bool> DeleteReviewAsync(string reviewId);
    }
}
