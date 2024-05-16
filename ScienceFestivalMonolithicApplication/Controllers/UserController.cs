using Microsoft.AspNetCore.Mvc;
using ScienceFestivalMonolithicApplication.DTOs.UserDTO;
using ScienceFestivalMonolithicApplication.Interfaces;
using ScienceFestivalMonolithicApplication.Services;

namespace ScienceFestivalMonolithicApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


  

        [HttpGet("performers")]
        public async Task<IActionResult> GetPerformers()
        {
            try
            {
                var performers = await _userService.GetAllPerformers();
                return Ok(performers);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetPerformerById(string id)
        {
            try
            {
                var performer = await _userService.GetUserById(id);
                return Ok(performer);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("juries")]
        public async Task<IActionResult> GetJuries()
        {
            try
            {
                var juries = await _userService.GetAllJuries();
                return Ok(juries);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
