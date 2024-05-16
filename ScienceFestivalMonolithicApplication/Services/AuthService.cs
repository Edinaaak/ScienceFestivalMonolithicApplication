using Microsoft.AspNetCore.Identity;
using ScienceFestivalMonolithicApplication.DTOs.UserDTO;
using ScienceFestivalMonolithicApplication.Interfaces;
using ScienceFestivalMonolithicApplication.Models;
using System.Data;

namespace ScienceFestivalMonolithicApplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Models.User> _userManager;
        private readonly  TokenService _tokenService;
        private readonly RoleManager<AppRole> _roleManager;

        public AuthService(UserManager<Models.User> userManager, TokenService tokenService, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }
        public async Task<UserAuthResponse> Login(UserLoginRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser == null)
            {
                return new UserAuthResponse
                {
                    Error = "User does not exist",
                    StatusCode = 404
                };
            }
            var result = await _userManager.CheckPasswordAsync(existingUser, request.Password);
            if (!result)
            {
                return new UserAuthResponse
                {
                    Error = "Invalid password",
                    StatusCode = 401
                };
            }

            var token = _tokenService.GenerateToken(existingUser);
            var roleList = await _userManager.GetRolesAsync(existingUser);
            var role = roleList.FirstOrDefault();
            return new UserAuthResponse
            {
                Token = token,
                User = existingUser,
                Role = role,
                StatusCode = 200
            };
        }

        public async Task<UserAuthResponse> Register(UserRegisterRequest request, string password)
        {
            var  existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser != null)
            {
                return new UserAuthResponse
                {
                    Error = "User already exists",
                    StatusCode = 400
                };
            }

            var existingRole = await _roleManager.FindByNameAsync(request.Role);
            if (existingRole == null)
            {
                return new UserAuthResponse
                {
                    Error = "Role does not exist",
                    StatusCode = 404
                };
            }

            var newUser = await _userManager.CreateAsync(new Models.User
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Age = request.Age
            }, password);

            if(!newUser.Succeeded)
            {
                return new UserAuthResponse
                {
                    Error = "Invalid user details",
                    StatusCode = 400
                };
            }


            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(request.UserName), request.Role.ToString());
            var token = _tokenService.GenerateToken(await _userManager.FindByNameAsync(request.UserName));
            return new UserAuthResponse
            {
                Token = token,
                User = await _userManager.FindByNameAsync(request.UserName),
                Role = request.Role.ToString(),
                StatusCode = 200
            };


        }
    }
}
