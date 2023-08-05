using Palmfit.Core.Dtos;
using Palmfit.Data.Entities;

namespace Palmfit.Core.Services
{
    public interface IAppUserRepository
    {
        Task<string> CreateUser(SignUpDto userRequest);
        

    }
}