using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementAPI.Core.Dto;

namespace TaskManagementAPI.Core.Services
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(UserDto userDto);

        Task<UserDto> ReadUserAsync(string userId);

        Task<IEnumerable<UserDto>> ReadAllUsersAsync();

        Task<bool> UpdateUserAsync(string userId, UserDto updatedUserDto);

        Task<bool> DeleteUserAsync(string userId);

                         
    }
}
