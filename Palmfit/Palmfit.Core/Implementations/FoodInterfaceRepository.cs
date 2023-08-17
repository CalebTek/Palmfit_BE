using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class FoodInterfaceRepository : IFoodInterfaceRepository
    {
        private readonly PalmfitDbContext _dbcontext;

        public FoodInterfaceRepository(PalmfitDbContext dbcontext)
        {
           _dbcontext = dbcontext;
        }

        public async Task<List<Food>> GetAllFoodAsync() 
        {
            return await _dbcontext.Foods.ToListAsync();
        }

        public async Task<List<Food>> SearchFood(string searchTerms)
        {
            var foods = await _dbcontext.Foods.ToListAsync();
            if (searchTerms != null && searchTerms.Length > 0)
            {
                foods = foods.Where(x => searchTerms.Any(term => x.Name.Contains(term))).OrderByDescending(x => x.CreatedAt).ToList();
            }
            return foods;
        }



    }
}
