using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TournamentManager.Data;
using TournamentManager.Enum;
using TournamentManager.Models.Entities;
using TournamentManager.Models.ViewModel;
using TournamentManager.Services;

namespace TournamentManager.Controllers
{
    public class TournamentController(ITournamentLookupService lookupService) : Controller
    {
        private readonly ITournamentLookupService _lookupService = lookupService;

        [HttpGet("ChoosePairing")]
        public async Task<IActionResult> ChoosePairing()
        {
            var viewModel = await _lookupService.GetPairingOptions();
            return View(viewModel);
        }

        [HttpGet("GetTournamentInfo")]
        public async Task<IActionResult> GetTournamentInfo(Pairing model)
        {
            var viewModel = await _lookupService.GetTournamentInfo(model.Method.ToString());
            return View(viewModel);
        }

        [HttpPost("CreateTournament")]
        public async Task<IActionResult> CreateTournament(Tournament model)
        {
            return View();
        }

    }
}
