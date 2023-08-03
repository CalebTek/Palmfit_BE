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

        public async Task<Food> GetFoodByIdAsync(string id)
        {
            return await _db.Foods.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<string> DeleteAsync(string id)
        {
           
            var existingFood = await GetFoodByIdAsync(id);
            if (existingFood == null)
            {
                return $"Food with Id: {id} cannot be found";
            }
            _db.Foods.Remove(existingFood);
            await _db.SaveChangesAsync();
            return "Successfully deleted";
        }
    }
 }
