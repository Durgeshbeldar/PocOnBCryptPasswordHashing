using PasswordHasher.DTOs;
using PasswordHasher.Models;
using PasswordHasher.Repositories;

namespace PasswordHasher.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public UserDto AddUser(UserDto userDto)
        {
            // Bcrypt Password Hasher is used here... POC Concept Demonstration.
            string passwordHashed = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            // We Can Used Auto Mapper Package But Here Due to Small Implementation I Did Not Used.
            var user = new User()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = passwordHashed
            };
            _repository.Add(user);

            // Message is added to Custom DTO Used for User Details
            userDto.Message = "User Added To Database Successfully";
            return userDto;
        }
        public UserDto Login(UserDto userDto)
        {
            var exUser = _repository.Get().Where(user => user.Email == userDto.Email).FirstOrDefault();

            // User Not Found Case...

            if (exUser == null)
            {
                userDto.Message = "User Not Found With The Given User Details.";
                return userDto;
            }
            
            // Will Execute For Successfull Login Attempt 

            else if (BCrypt.Net.BCrypt.Verify(userDto.Password, exUser.Password))
            {
                userDto.Message = "Welcome to Home Page Login Successfull...";
                userDto.Name = exUser.Name;
                return userDto;
            }

            // Invalid Credentials OR Login Failed

            userDto.Message = "Login Failed, Invalid Credentials...";
            return userDto;
        }
    }
}
