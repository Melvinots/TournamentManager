using Microsoft.AspNetCore.Mvc.Rendering;
using TournamentManager.Models.Entities;

namespace TournamentManager.Models.ViewModel
{
    public class TournamentViewModel
    {
        public List<Player>? Players { get; set; }
        public string MethodType { get; set; } = string.Empty;
        public string TimeControl { get; set; } = string.Empty;
        public int? Rounds { get; set; }


        public string Method { get; set; } = string.Empty;
        public List<SelectListItem> MethodTypes { get; set; } = new();
        public List<SelectListItem> TimeControls { get; set; } = new();

    }
}
