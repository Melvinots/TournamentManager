namespace TournamentManager.Models.Entities
{
    public class Match
    {
        public int MatchId { get; set; }
        public int? TournamentId { get; set; }
        public int? RoundNumber { get; set; }
        public int? WhitePlayerId { get; set; }
        public int? BlackPlayerId { get; set; }
        public string? Result { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? BoardNumber { get; set; }
        public DateTime? CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
    }
}
