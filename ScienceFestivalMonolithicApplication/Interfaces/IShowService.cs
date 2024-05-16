using ScienceFestivalMonolithicApplication.DTOs.ShowDTO;
using ScienceFestivalMonolithicApplication.Models;

namespace ScienceFestivalMonolithicApplication.Interfaces
{
    public interface IShowService
    {

        public Task<Show> AddShow(ShowCreateRequest show);
        public Task<List<Show>> GetAllShows();
        public Task<Show> GetShowById(int showId);
        public Task<List<Show>> GetAcceptedShows();

        public Task<List<Show>> GetUnacceptedShows();

        public Task<Show> AcceptShow(int showId);

    }
}
