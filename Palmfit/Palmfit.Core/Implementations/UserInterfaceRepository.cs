using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class UserInterfaceRepository : IUserInterfaceRepository
    {

        private readonly PalmfitDbContext _db;

        public UserInterfaceRepository(PalmfitDbContext db)
        {
            _db = db;
        }
        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _db.Users.ToListAsync();

            return users.Select(user => new UserDto
            {
                Title = user.Title,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Image = user.Image,
                Address = user.Address,
                Area = user.Area,
                State = user.State,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                Country = user.Country,
            }).ToList();
        }
        public async Task<string> UpdateUserAsync(string id, UserDto userDto)
        {
            var user = await _db.Users.FindAsync(id);

            if (user == null)
                return "User not found.";

            user.Title = user.Title;
            user.FirstName = user.FirstName;
            user.MiddleName = user.MiddleName;
            user.LastName = user.LastName;
            user.Image = user.Image;
            user.Address = user.Address;
            user.Area = user.Area;
            user.State = user.State;
            user.Gender = user.Gender;
            user.DateOfBirth = user.DateOfBirth;
            user.Country = user.Country;

            try
            {
                await _db.SaveChangesAsync();
                return "User updated successfully.";
            }
            catch (Exception)
            {
                return "User failed to update.";
            }

        }
    }
}
