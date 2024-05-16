using Microsoft.AspNetCore.Mvc;
using ScienceFestivalMonolithicApplication.DTOs.UserDTO;
using ScienceFestivalMonolithicApplication.Interfaces;
using ScienceFestivalMonolithicApplication.Services;

namespace ScienceFestivalMonolithicApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("user-register")]
        public async Task<IActionResult> PerformerRegister(UserRegisterRequest userRegisterDTO)
        {
            try
            {
                var result = await _authService.Register(userRegisterDTO, userRegisterDTO.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("user-login")]
        public async Task<IActionResult> PerformerLogin(UserLoginRequest userLoginDTO)
        {
            try
            {
                var result = await _authService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
