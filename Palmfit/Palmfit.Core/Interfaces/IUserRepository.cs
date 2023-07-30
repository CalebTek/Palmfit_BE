using Palmfit.Data.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(SignUpDto userRequest);
    }
}
