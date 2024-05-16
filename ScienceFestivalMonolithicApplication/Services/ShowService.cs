using Microsoft.EntityFrameworkCore;
using ScienceFestivalMonolithicApplication.DTOs.ShowDTO;
using ScienceFestivalMonolithicApplication.Interfaces;
using ScienceFestivalMonolithicApplication.Models;
using ScienceFestivalMonolithicApplication.Persistance;

namespace ScienceFestivalMonolithicApplication.Services
{
    public class ShowService : IShowService
    {
        private readonly DatabaseContext context;
        public ShowService(DatabaseContext context)
        {
            this.context = context;
                
        }
        public async Task<Show> AcceptShow(int showId)
        {
           var show = await context.Shows.Where(s => s.Id == showId).FirstOrDefaultAsync();
            show.Accepted = true;
            await context.SaveChangesAsync();
            return show;

        }

        public async Task<Show> AddShow(ShowCreateRequest show)
        {
           var createShow = new Show
           {
                Name = show.Name,
                Description = show.Description,
                Accepted = false,
                UserId = show.UserId,
                ReleaseDate = DateTime.Now.ToString("yyyy-MM-dd")
        };
                await context.Shows.AddAsync(createShow);
                await context.SaveChangesAsync();
            return createShow;
        }

        public async Task<List<Show>> GetAcceptedShows()
        {
            var shows = await context.Shows.Where(s => s.Accepted == true).Include(s => s.Performer).ToListAsync();
            return shows;
        }

        public async Task<List<Show>> GetAllShows()
        {
            return await context.Shows.Include(s => s.Performer).ToListAsync();
        }

        public async Task<Show> GetShowById(int showId)
        {
            var show = await context.Shows.Where(s => s.Id == showId).Include(s => s.Performer).FirstOrDefaultAsync();
            return show;

        }

        public Task<List<Show>> GetUnacceptedShows()
        {
            var shows = context.Shows.Where(s => s.Accepted == false).Include(s => s.Performer).ToListAsync();
            return shows;
        }
    }
}
