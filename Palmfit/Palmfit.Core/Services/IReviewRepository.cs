using Palmfit.Core.Dtos;
﻿using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IReviewRepository 
    {
        Task<List<Review>> GetReviewsByUserIdAsync(string userId);

		Task<string> AddReview(ReviewDto reviewDTO, string userId);
    }
}
