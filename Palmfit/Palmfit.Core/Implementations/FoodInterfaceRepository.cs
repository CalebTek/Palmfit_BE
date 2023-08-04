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

        public async Task<IEnumerable<Food>> SearchFood(params string[] searchTerms)
        {
            IQueryable<Food> query = _db.Foods;
            if (searchTerms != null && searchTerms.Length > 0)
            {
                foreach (string term in searchTerms)
                {
                    if (!string.IsNullOrEmpty(term))
                    {
                        query = query.Where(x => searchTerms.Any(term => x.Name.Contains(term)));
                        
                    }
                }
            }
            return await query.ToListAsync();
        }

        
    }
}
