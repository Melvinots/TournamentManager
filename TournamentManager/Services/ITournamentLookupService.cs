using Microsoft.AspNetCore.Mvc.Rendering;
using TournamentManager.Models.ViewModel;

namespace TournamentManager.Services
{
    public interface ITournamentLookupService
    {
        Task<TournamentViewModel> GetTournamentInfo(string group);
        Task<PairingViewModel> GetPairingOptions();
    }

}
