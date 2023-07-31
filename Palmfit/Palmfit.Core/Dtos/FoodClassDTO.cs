using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Dtos
{
    public class FoodClassDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Day { get; set; }
        public ICollection<FoodDTO> Foods { get; set; }
    }
}
