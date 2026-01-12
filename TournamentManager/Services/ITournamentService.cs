using TournamentManager.Models.ViewModel;

namespace TournamentManager.Services
{
    public interface ITournamentService
    {
        Task<TournamentViewModel> CreateTournament(string group);
    }
}
