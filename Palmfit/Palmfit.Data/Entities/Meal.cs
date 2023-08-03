using Palmfit.Data.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Data.Entities
{
    public class Meal : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string FoodId { get; set; }
        public Food Food { get; set; }
        public MealOfDay MealOfDay { get; set; }
        public DaysOfWeek DaysOfWeek { get; set; }
        
    }
}
