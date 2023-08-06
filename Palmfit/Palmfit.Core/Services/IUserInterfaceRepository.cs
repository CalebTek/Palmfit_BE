using Data.Entities;
using Palmfit.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IUserInterfaceRepository
    {
        Task<string> UpdateUserAsync(string id, UserDto userDto);
        Task<UserDto> GetUserByIdAsync(string id);
    }
}
