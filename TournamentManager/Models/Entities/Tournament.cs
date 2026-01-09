namespace TournamentManager.Models.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public List<Player>? Players { get; set; }
        public string MethodType { get; set; }
        public string TimeControl { get; set; }
        public int? Rounds { get; set; }
    }
}
