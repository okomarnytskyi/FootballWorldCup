using FootballWorldCup.Implementation.Models;

namespace FootballWorldCup.Implementation.Storages
{
    internal interface IFootballStorage : IStorage<FootballMatch>
    {
        bool ContainsFootballMatch(string homeTeamName, string awayTeamName);
    }
}