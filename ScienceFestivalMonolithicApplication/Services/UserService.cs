using Microsoft.AspNetCore.Identity;
using ScienceFestivalMonolithicApplication.DTOs.UserDTO;
using ScienceFestivalMonolithicApplication.Interfaces;
using ScienceFestivalMonolithicApplication.Models;

namespace ScienceFestivalMonolithicApplication.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IList<User>> GetAllJuries()
        {

            var juries = await _userManager.GetUsersInRoleAsync("Jury");
            return juries;

        }

        public async Task<IList<User>> GetAllPerformers()
        {
            var performers = await _userManager.GetUsersInRoleAsync("Performer");
            return performers;
        }

        public async Task<User> GetUserById(string id)
        {
            var performer = await _userManager.FindByIdAsync(id);
            if (performer == null)
            {
                throw new Exception("Performer not found.");
            }
            return performer;
        }

        public async Task<User> Login(UserLoginRequest userLoginDTO)
        {

            var user = await _userManager.FindByNameAsync(userLoginDTO.UserName);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (await _userManager.CheckPasswordAsync(user, userLoginDTO.Password))
            {
                return user;
            }
            else
            {
                throw new Exception("Username and password not match");
            }
        }

        public async Task<User> Register(UserRegisterRequest userRegisterDTO)
        {
            var user = new User
            {
                UserName = userRegisterDTO.UserName,
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                Age = userRegisterDTO.Age,
                PhoneNumber = userRegisterDTO.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);

            await _userManager.AddToRoleAsync(user, userRegisterDTO.Role.ToString());

            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                throw new Exception("Registration failed. Reason: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
