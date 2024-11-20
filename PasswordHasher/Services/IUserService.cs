using PasswordHasher.DTOs;
using PasswordHasher.Models;

namespace PasswordHasher.Services
{
    public interface IUserService
    {
        public UserDto AddUser(UserDto userDto);
        public UserDto Login(UserDto userDto);
    }
}
