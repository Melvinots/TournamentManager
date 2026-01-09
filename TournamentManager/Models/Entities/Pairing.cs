using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TournamentManager.Enum;

namespace TournamentManager.Models.Entities
{
    public class Pairing
    {
        [Required]
        public PairingMethod Method { get; set; }
        public List<SelectListItem> MethodOptions { get; set; }
    }
}
