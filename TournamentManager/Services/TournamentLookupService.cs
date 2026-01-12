using Microsoft.AspNetCore.Mvc.Rendering;
using TournamentManager.Models.ViewModel;
using TournamentManager.Enum;
using TournamentManager.Repositories;

namespace TournamentManager.Services
{
    public class TournamentLookupService(ITournamentRepository tournamentRepository) : ITournamentLookupService
    {
        private readonly ITournamentRepository _tournamentRepository = tournamentRepository;

        public async Task<FormatViewModel> GetFormatOptions()
        {
            var infos = await _tournamentRepository.GetLookupAsync("", LookupKeys.FormatInfo) ?? new List<SelectListItem>();

            var viewModel = new FormatViewModel()
            {
                FormatOptions = await _tournamentRepository.GetLookupAsync("", LookupKeys.Format),
                FormatInfos = infos.ToDictionary(info => info.Value ?? string.Empty, info => info.Text ?? string.Empty)
            };

            return viewModel;
        }

        public async Task<TournamentViewModel> GetTournamentInfo(string group)
        {
            var viewModel = new TournamentViewModel()
            {
                Format = await _tournamentRepository.GetFormatAsync(group, LookupKeys.Format),
                FormatTypes = await _tournamentRepository.GetLookupAsync(group, LookupKeys.FormatType),
                TimeControls = await _tournamentRepository.GetLookupAsync(group, LookupKeys.TimeControl)
            };
                
            return viewModel;
        }
    }

}
