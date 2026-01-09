using Microsoft.AspNetCore.Mvc.Rendering;
using TournamentManager.Data.TournamentInfo;
using TournamentManager.Models.ViewModel;
using TournamentManager.Enum;

namespace TournamentManager.Services
{
    public class TournamentLookupService(ITournamentInfo tournamentInfo) : ITournamentLookupService
    {
        private readonly ITournamentInfo _tournamentInfo = tournamentInfo;

        public async Task<TournamentViewModel> GetTournamentInfo(string group)
        {
            var viewModel = new TournamentViewModel()
            {
                Method = await _tournamentInfo.GetPairingMethod(group, LookupKeys.Method),
                MethodTypes = await _tournamentInfo.GetLookupAsync(group, LookupKeys.MethodType),
                TimeControls = await _tournamentInfo.GetLookupAsync(group, LookupKeys.TimeControl)
            };
                
            return viewModel;
        }

        public async Task<PairingViewModel> GetPairingOptions()
        {
            var infos = await _tournamentInfo.GetLookupAsync("", LookupKeys.MethodInfo) ?? new List<SelectListItem>();

            var viewModel = new PairingViewModel()
            {
                MethodOptions = await _tournamentInfo.GetLookupAsync("", LookupKeys.Method),
                MethodInfo = infos.ToDictionary(info => info.Value ?? string.Empty, info => info.Text ?? string.Empty)
            };

            return viewModel;
        }

    }

}
