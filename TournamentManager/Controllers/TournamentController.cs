using Microsoft.AspNetCore.Mvc;
using TournamentManager.Models.Entities;
using TournamentManager.Models.ViewModel;
using TournamentManager.Services;

namespace TournamentManager.Controllers
{
    public class TournamentController(ITournamentService tournamentService, ITournamentLookupService lookupService) : Controller
    {
        private readonly ITournamentService _tournamentService = tournamentService;
        private readonly ITournamentLookupService _lookupService = lookupService;

        [HttpGet("SelectFormat")]
        public async Task<IActionResult> SelectFormat()
        {
            var viewModel = await _lookupService.GetFormatOptions();
            return View(viewModel);
        }

        [HttpGet("GetTournamentInfo")]
        public async Task<IActionResult> GetTournamentInfo(FormatViewModel model)
        {
            var viewModel = await _lookupService.GetTournamentInfo(model.Method.ToString());
            return View(viewModel);
        }

        [HttpPost("CreateTournament")]
        public async Task<IActionResult> CreateTournament(TournamentViewModel model)
        {
            //var viewModel = await _tournamentService.CreateTournament(model);
            return View();
        }

    }
}
