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
        public async Task<Food?> DeleteAsync(string id)
        {
           
            var existingFood = await _db.Foods.FirstOrDefaultAsync(x => x.Id == id);
            if (existingFood == null)
            {
                return null;
            }
            _db.Foods.Remove(existingFood);
            await _db.SaveChangesAsync();
            return existingFood;
        }
    }
 }
