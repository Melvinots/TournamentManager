using Microsoft.AspNetCore.Mvc.Rendering;

namespace TournamentManager.Models.ViewModel
{
    public class FormatViewModel
    {
        public string Method { get; set; } = string.Empty;
        public List<SelectListItem>? FormatOptions { get; set; }
        public Dictionary<string, string>? FormatInfos { get; set; }
    }
}
