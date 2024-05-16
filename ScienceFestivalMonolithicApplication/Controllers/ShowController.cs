using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScienceFestivalMonolithicApplication.DTOs.ShowDTO;
using ScienceFestivalMonolithicApplication.Interfaces;

namespace ScienceFestivalMonolithicApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService = showService;
        }


        [HttpGet("get-shows")]
        [Authorize]
        public async Task<IActionResult> GetShows()
        {
            try
            {
                var shows = await _showService.GetAllShows();
                return Ok(shows);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-show-by-id/{id}")]
        public async Task<IActionResult> GetShowById(int id)
        {
            try
            {
                var show = await _showService.GetShowById(id);
                return Ok(show);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("add-show")]
        public async Task<IActionResult> AddShow(ShowCreateRequest showDTO)
        {
            try
            {
                var show = await _showService.AddShow(showDTO);
                return Ok(show);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-accepted-shows")]
        public async Task<IActionResult> GetAcceptedShows()
        {
            try
            {
                var shows = await _showService.GetAcceptedShows();
                return Ok(shows);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-unaccepted-shows")]
        public async Task<IActionResult> GetUnacceptedShows()
        {
            try
            {
                var shows = await _showService.GetUnacceptedShows();
                return Ok(shows);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("accept-show/{id}")]
        public async Task<IActionResult> AcceptShow(int id)
        {
            try
            {
                var show = await _showService.AcceptShow(id);
                return Ok(show);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
