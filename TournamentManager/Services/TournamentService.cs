using TournamentManager.Models.ViewModel;

namespace TournamentManager.Services
{
    public class TournamentService : ITournamentService
    {
        public async Task<TournamentViewModel> CreateTournament(string group)
        {
            // Implementation goes here
            return await Task.FromResult(new TournamentViewModel());
        }
    }
}
