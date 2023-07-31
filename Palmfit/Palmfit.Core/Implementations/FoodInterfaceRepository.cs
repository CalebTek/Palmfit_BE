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
        private readonly PalmfitDbContext _db;

        public FoodInterfaceRepository(PalmfitDbContext db)
        {
           _db = db;
        }

        public async Task<List<Food>> GetAllFoodAsync() 
        {
            return await _db.Foods.ToListAsync();
        }

        public async Task<List<FoodClass>> SearchFoodByCategory(string category)
        {
            IQueryable<FoodClass> query = _db.FoodClasses;

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(food => EF.Functions.Like(food.Name, $"%{category}%"));
            }

            return await query.ToListAsync();
        }

        public async Task<List<Food>> SearchFoodByName(string name)
        {
            IQueryable<Food> query = _db.Foods;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(food => EF.Functions.Like(food.Name, $"%{name}%"));
            }

            return await query.ToListAsync();
        }

    }
}
