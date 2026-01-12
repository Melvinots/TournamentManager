using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc.Rendering;
using TournamentManager.Models.ViewModel;

namespace TournamentManager.Services
{
    public interface ITournamentLookupService
    {
        Task<FormatViewModel> GetFormatOptions();
        Task<TournamentViewModel> GetTournamentInfo(string group);
    }

}
