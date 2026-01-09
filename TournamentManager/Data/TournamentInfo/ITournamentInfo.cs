using Microsoft.AspNetCore.Mvc.Rendering;
using TournamentManager.Models.ViewModel;

namespace TournamentManager.Data.TournamentInfo
{
    public interface ITournamentInfo
    {
        Task<string> GetPairingMethod(string group, string key);
        Task<List<SelectListItem>> GetLookupAsync(string group, string key);
    }
}
