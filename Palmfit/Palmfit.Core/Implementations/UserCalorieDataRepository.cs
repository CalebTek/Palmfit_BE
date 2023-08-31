using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class UserCalorieDataRepository : IUserCalorieDataRepository
    {
        private readonly PalmfitDbContext _dbContext;

        public UserCalorieDataRepository(PalmfitDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserCalorieDataAsync(UserCalorieDataDto userCalorieDataDto, string userId)
        {
            var data = new UserCalorieData()
            {
                Id = Guid.NewGuid().ToString(),
                WeightGoal = userCalorieDataDto.WeightGoal,
                ActivityLevel = userCalorieDataDto.ActivityLevel,
                Age = userCalorieDataDto.Age,
                Height = userCalorieDataDto.Height,
                Weight = userCalorieDataDto.Weight,
                Gender = userCalorieDataDto.Gender,
                AppUserId = userId,
                IsDeleted = false,
                CreatedAt = DateTime.Now,   
                UpdatedAt = DateTime.Now
                
            };
            await _dbContext.userCaloriesData.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }



        public async Task<UserCalorieData> GetUserCalorieDataByIdAsync(string id)
        {
            return await _dbContext.userCaloriesData.SingleOrDefaultAsync(user => user.AppUserId == id);
        }


    }
}
