using TournamentManager.Services;
using TournamentManager.Models.Lookups;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TournamentManager.Data.TournamentInfo
{
    public class TournamentInfo(DbManager mgr) : ITournamentInfo
    {
        private readonly DbManager _mgr = mgr;

        private SqlCommand BuildTournamentInfoSP(string group, string key)
        {
            var cmd = _mgr.BuildSP("pr_GetTournamentInfo");
            _mgr.AddParameter(cmd, "Group", SqlDbType.VarChar, group);
            _mgr.AddParameter(cmd, "Key", SqlDbType.VarChar, key);
            return cmd;
        }

        public async Task<string> GetPairingMethod(string group, string key)
        {
            var cmd = BuildTournamentInfoSP(group, key);
            var lookups = await _mgr.ExecuteReaderAsync<TournamentLookup>(cmd);

            return lookups.FirstOrDefault()?.Description ?? "Default";
        }

        public async Task<List<SelectListItem>> GetLookupAsync(string group, string key)
        {
            var cmd = BuildTournamentInfoSP(group, key);
            var lookups = await _mgr.ExecuteReaderAsync<TournamentLookup>(cmd) ?? new List<TournamentLookup>();

            var selectItems = lookups
                        .Select(t => new SelectListItem
                        {
                            Value = t.Value ?? string.Empty,
                            Text = t.Description ?? string.Empty
                        })
                        .ToList();

            return selectItems;
        }
    }
}
