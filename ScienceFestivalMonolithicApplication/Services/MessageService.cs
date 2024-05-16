using Microsoft.EntityFrameworkCore;
using ScienceFestivalMonolithicApplication.DTOs.MessageDTO;
using ScienceFestivalMonolithicApplication.Interfaces;
using ScienceFestivalMonolithicApplication.Models;
using ScienceFestivalMonolithicApplication.Persistance;

namespace ScienceFestivalMonolithicApplication.Services
{
    public class MessageService : IMessageService
    {
        private readonly DatabaseContext context;
        public MessageService(DatabaseContext context)
        {
            this.context = context;
        }
        public async Task<Message> AddMessage(MessageCreateRequest message)
        {
            var createdMessage = new Message
            {
                UserId = message.JuryId,
                ShowId = message.ShowId,
                Comment = message.Comment
            };
            await context.AddAsync(createdMessage);
            await context.SaveChangesAsync();
            return createdMessage;

           
        }

        public async Task<List<Message>> GetAllMessages()
        {
            return await context.Messagees.ToListAsync();
        }

        public async Task<Message> GetMessageById(int messageId)
        {
            var message = await context.Messagees.FirstOrDefaultAsync(m => m.Id == messageId);
            return message;
        }

        public async Task<List<Message>> GetMessagesForShow(int showId)
        {
            var messages = await context.Messagees.Where(m => m.ShowId == showId).ToListAsync();
            return messages;
        }

        public async Task<List<Message>> GetMessagesForUser(int userId)
        {
           var messages = await context.Messagees.Where(m => m.UserId == userId).ToListAsync();
            return messages;
        }
    }
}
