using Palmfit.Core.Dtos;
using Palmfit.Data.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class FoodInterfaceRepository
    {
        //prop  
        private readonly PalmfitDbContext _dbContext;

        //ctor
        public FoodInterfaceRepository(PalmfitDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ICollection<FoodDto>> GetFoodByCategory(string id)
        {
            if (id == null) throw new ArgumentNullException("id");

            var getFoodData = _dbContext.Foods.Where(x => x.FoodClassId == id);
            if (getFoodData == null)
                return null;

            List<FoodDto> result = null;

            foreach (var food in getFoodData)
            {
                FoodDto newEntry = new()
                {
                    Name = food.Name,
                    Description = food.Description,
                    Details = food.Details,
                    Origin = food.Origin,
                    Image = food.Image,
                    Calorie = food.Calorie,
                    Unit = food.Unit,
                };

                result.Add(newEntry);
            }

            return result;
        }
    }
}
