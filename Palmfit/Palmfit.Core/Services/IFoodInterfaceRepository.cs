using Palmfit.Core.Dtos;
using Palmfit.Core.Implementations;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
     
    public interface IFoodInterfaceRepository 
    public interface IFoodInterfaceRepository
    {
        Task<List<Food>> GetAllFoodAsync();
        Task<string> UpdateFoodAsync(string id, UpdateFoodDto foodDto);

        Task<ICollection<FoodDto>> GetFoodByCategory(string id);
       
    }
}
