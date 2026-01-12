namespace TournamentManager.Models.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Format { get; set; }
        public int? Rounds { get; set; }
        public string? TimeControl { get; set; }
    }
}
