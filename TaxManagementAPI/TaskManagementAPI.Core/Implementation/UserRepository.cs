using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementAPI.Core.Dto;
using TaskManagementAPI.Core.Services;
using TaskManagementAPI.Model.Entities;
using TaskManagementAPI.Model.TaskDbContext;

namespace TaskManagementAPI.Core.Implementation
{
     
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementDbContext _context;

        public UserRepository(TaskManagementDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateUserAsync(UserDto userDto)
        {
            try
            {
                if (await _context.Users.AnyAsync(u => u.Email == userDto.Email))
                {
                    return false;
                }

                var createdUser = new User
                {
                    UserId = Guid.NewGuid().ToString(),
                    Name = userDto.Name,
                    Email = userDto.Email,
                };

                _context.Users.Add(createdUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    return false;
                }

                user.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<UserDto>> ReadAllUsersAsync()
        {
            try
            {
                var allUsers = await _context.Users
                    .Where(u => !u.IsDeleted)
                    .Select(user => new UserDto
                    {
                        Name = user.Name,
                        Email = user.Email,
                    }).ToListAsync();

                return allUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return Enumerable.Empty<UserDto>();
            }
        }

        public async Task<UserDto> ReadUserAsync(string userId)
        {
            try
            {
                var getUser = await _context.Users
                    .Where(u => u.UserId == userId && !u.IsDeleted)
                    .FirstOrDefaultAsync();

                if (getUser == null)
                {
                    return null;
                }

                var userDto = new UserDto
                {
                    Name = getUser.Name,
                    Email = getUser.Email
                };
                return userDto;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            }



        }

        public async Task<bool> UpdateUserAsync(string userId, UserDto updatedUserDto)
        {
            try
            {
                var getUser = await _context.Users
                    .Where(u => u.UserId == userId && !u.IsDeleted)
                    .FirstOrDefaultAsync();
                if (getUser == null)
                {
                    return false;
                }

                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserId != userId && u.Email == updatedUserDto.Email);
                if (existingUser != null)
                {
                    return false;
                }

                getUser.Name = updatedUserDto.Name; 
                getUser.Email = updatedUserDto.Email;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
