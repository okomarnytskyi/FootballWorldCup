using FootballWorldCup.Implementation.Models;
using System.Linq;

namespace FootballWorldCup.Implementation.Storages
{
    internal class FootballStorage : BaseStorage<FootballMatch>, IFootballStorage
    {
        public bool ContainsFootballMatch(string homeTeamName, string awayTeamName)
        {
            return GetAll().Any(s => s.HomeTeamName == homeTeamName
                                  && s.AwayTeamName == awayTeamName);
        }
    }
}
