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

        public async Task<ApiResponse<FoodClassDto>> CreateFoodClass(FoodClassDto foodClassDto)
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

                var createdFoodClassDto = new FoodClassDto
                {
                    Name = foodClassEntity.Name,
                    Description = foodClassEntity.Description,
                    Details = foodClassEntity.Details,
                };

                return ApiResponse<FoodClassDto>.Success(createdFoodClassDto, "Food class created successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<FoodClassDto>.Failed(null!, "Failed to create food class.", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<List<FoodClassDto>>> GetAllFoodClasses()
        {
            try
            {
                var foodClasses = await _context.FoodClasses.ToListAsync();

                var foodClassDtos = foodClasses.Select(foodClass => new FoodClassDto
                {
                    Name = foodClass.Name,
                    Description = foodClass.Description,
                    Details = foodClass.Details,
                }).ToList();

                return ApiResponse<List<FoodClassDto>>.Success(foodClassDtos, "Successfully retrieved all food classes.");
            }
            catch (Exception ex)
            {
                return ApiResponse<List<FoodClassDto>>.Failed(null!, "Failed to retrieve food classes.", new List<string> { ex.Message });
            }
        }


        public async Task<ApiResponse<string>> DeleteFoodClass(string foodClassId)
        {
            try
            {
                var foodClassEntity = await _context.FoodClasses.FindAsync(foodClassId);

                if (foodClassEntity == null)
                {
                    return ApiResponse<string>.Failed(null!, "Food class not found.", new List<string> { "Food class with the specified ID does not exist." });
                }

                _context.FoodClasses.Remove(foodClassEntity);
                await _context.SaveChangesAsync();

                return (ApiResponse<string>)ApiResponse<string>.Success(null, "Food class deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Failed(null!, "Failed to delete food class.", new List<string> { ex.Message });
            }
        }


        public async Task<ApiResponse<FoodClassDto>> UpdateFoodClass(string foodClassId, FoodClassDto updatedFoodClassDto)
        {
            try
            {
                var foodClassEntity = await _context.FoodClasses.FindAsync(foodClassId);

                if (foodClassEntity == null)
                {
                    return ApiResponse<FoodClassDto>.Failed(null!, "Food class not found.", new List<string> { "Food class with the specified ID does not exist." });
                }

                foodClassEntity.Name = updatedFoodClassDto.Name;
                foodClassEntity.Description = updatedFoodClassDto.Description;
                foodClassEntity.Details = updatedFoodClassDto.Details;

                await _context.SaveChangesAsync();

                var updatedFoodClassDtoResponse = new FoodClassDto
                {
                    Name = foodClassEntity.Name,
                    Description = foodClassEntity.Description,
                    Details = foodClassEntity.Details,
                };

                return ApiResponse<FoodClassDto>.Success(updatedFoodClassDtoResponse, "Food class updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<FoodClassDto>.Failed(null!, "Failed to update food class.", new List<string> { ex.Message });
            }
        }

    }
}
