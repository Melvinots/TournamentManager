using Microsoft.AspNetCore.Mvc.Rendering;
using TournamentManager.Models.ViewModel;

namespace TournamentManager.Repositories
{
    public interface ITournamentRepository
    {
        Task<string> GetFormatAsync(string group, string key);
        Task<List<SelectListItem>> GetLookupAsync(string group, string key);
    }
}
