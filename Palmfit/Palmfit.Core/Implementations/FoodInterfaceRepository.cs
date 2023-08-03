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
        private readonly PalmfitDbContext _context;

        public FoodInterfaceRepository(PalmfitDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateFoodClass(FoodClassDto foodClassDto)
        {
            try
            {
                var foodClassEntity = new FoodClass
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = foodClassDto.Name,
                    Description = foodClassDto.Description,
                    Details = foodClassDto.Details,
                };

                _context.FoodClasses.Add(foodClassEntity);
                await _context.SaveChangesAsync();

                return "FoodClass Created Successfully";
            }
            catch (Exception ex)
            {
                return "Failed To Create Foodclass";
            }
        }
    }
}
