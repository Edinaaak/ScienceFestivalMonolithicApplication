using ScienceFestivalMonolithicApplication.DTOs.MessageDTO;
using ScienceFestivalMonolithicApplication.Models;

namespace ScienceFestivalMonolithicApplication.Interfaces
{
    public interface IMessageService
    {

        public Task<Message> AddMessage(MessageCreateRequest message);
        public Task<List<Message>> GetAllMessages();

        public Task<List<Message>> GetMessagesForUser(int userId);

        public Task<List<Message>> GetMessagesForShow(int showId);

        public Task<Message> GetMessageById(int messageId);
    }
}
