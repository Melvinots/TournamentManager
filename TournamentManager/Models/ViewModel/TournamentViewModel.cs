using Microsoft.AspNetCore.Mvc.Rendering;

namespace TournamentManager.Models.ViewModel
{
    public class TournamentViewModel
    {
        public string FormatType { get; set; } = string.Empty;
        public string TimeControl { get; set; } = string.Empty;
        public int? Rounds { get; set; }


        public string Format { get; set; } = string.Empty;
        public List<SelectListItem> FormatTypes { get; set; } = new();
        public List<SelectListItem> TimeControls { get; set; } = new();

    }
}
