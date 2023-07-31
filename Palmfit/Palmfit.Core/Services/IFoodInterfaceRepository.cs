using Palmfit.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IFoodInterfaceRepository
    {
        Task<ApiResponse<FoodClassDto>> CreateFoodClass(FoodClassDto foodClassDto);
        Task<ApiResponse<List<FoodClassDto>>> GetAllFoodClasses();
        Task<ApiResponse<string>> DeleteFoodClass(string foodClassId);
        Task<ApiResponse<FoodClassDto>> UpdateFoodClass(string foodClassId, FoodClassDto updatedFoodClassDto);
    }
}
