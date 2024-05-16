using ScienceFestivalMonolithicApplication.DTOs.UserDTO;
using ScienceFestivalMonolithicApplication.Models;

namespace ScienceFestivalMonolithicApplication.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(UserRegisterRequest userRegisterDTO);

        Task<User> Login(UserLoginRequest userLoginDTO);

        Task<IList<User>> GetAllPerformers();

        Task<User> GetUserById(string id);

        Task<IList<User>> GetAllJuries();
    }
}
