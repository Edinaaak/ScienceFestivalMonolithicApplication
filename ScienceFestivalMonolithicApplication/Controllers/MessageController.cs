using Microsoft.AspNetCore.Mvc;
using ScienceFestivalMonolithicApplication.DTOs.MessageDTO;
using ScienceFestivalMonolithicApplication.Interfaces;

namespace ScienceFestivalMonolithicApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("get-messages")]
        public async Task<IActionResult> GetMessages()
        {
            try
            {
                var messages = await _messageService.GetAllMessages();
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessage(MessageCreateRequest messageDTO)
        {
            try
            {
                var message = await _messageService.AddMessage(messageDTO);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-messages-for-user/{id}")]
        public async Task<IActionResult> GetMessagesForUser(int id)
        {
            try
            {
                var messages = await _messageService.GetMessagesForUser(id);
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-messages-for-show/{id}")]
        public async Task<IActionResult> GetMessagesForShow(int id)
        {
            try
            {
                var messages = await _messageService.GetMessagesForShow(id);
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



       
    }
}
