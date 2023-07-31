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
    {
        Task<List<Food>> GetAllFoodAsync();
       
    }
}
