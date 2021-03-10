using FootballWorldCup.Implementation.Models;
using System;

namespace FootballWorldCup.Implementation.Managers
{
    public interface IManager
    {
        FootballScoreboard GetScoreboard();
        Guid StartGame(string homeTeamName, string awayTeamName);
        void FinishGame(Guid id);
        void HomeTeamScored(Guid id);
        void AwayTeamScored(Guid id);
    }
}