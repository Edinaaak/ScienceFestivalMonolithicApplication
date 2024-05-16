using Microsoft.AspNetCore.Identity.Data;
using ScienceFestivalMonolithicApplication.DTOs.UserDTO;

namespace ScienceFestivalMonolithicApplication.Interfaces
{
    public interface IAuthService
    {
        Task<UserAuthResponse> Register(UserRegisterRequest request, String password);

        Task<UserAuthResponse> Login(UserLoginRequest request);
    }
}
