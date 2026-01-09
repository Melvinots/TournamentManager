using Microsoft.AspNetCore.Mvc.Rendering;
using TournamentManager.Models.Entities;

namespace TournamentManager.Models.ViewModel
{
    public class PairingViewModel
    {
        public string Method { get; set; }

        public List<SelectListItem> MethodOptions { get; set; }

        public Dictionary<string, string> MethodInfo { get; set; }
    }
}
