using FootballWorldCup.Implementation.Exceptions;
using FootballWorldCup.Implementation.Models;
using FootballWorldCup.Implementation.Storages;
using System;
using System.Linq;

namespace FootballWorldCup.Implementation.Managers
{
    public class FootballGamesManager : IManager
    {
        private readonly IFootballStorage _storage;

        public FootballGamesManager()
        {
            _storage = new FootballStorage();
        }

        public FootballScoreboard GetScoreboard()
        {
            var result = _storage.GetAll()
                                 .OrderByDescending(s => s.HomeTeamScore + s.AwayTeamScore)
                                 .ThenByDescending(s => s.AddedRecordTime);

            return new FootballScoreboard
            {
                FootballMatches = result
            };
        }

        public Guid StartGame(string homeTeamName, string awayTeamName)
        {
            if (_storage.ContainsFootballMatch(homeTeamName, awayTeamName))
            {
                throw new FootballWorldCupException($"Match between {homeTeamName} and {awayTeamName} already exists.");
            }

            return _storage.Add(new FootballMatch
            {
                HomeTeamName = homeTeamName,
                AwayTeamName = awayTeamName,
                HomeTeamScore = 0,
                AwayTeamScore = 0,
                AddedRecordTime = DateTime.UtcNow
            });
        }

        public void FinishGame(Guid id)
        {
            _ = _storage.GetById(id);

            _storage.Delete(id);
        }

        public void HomeTeamScored(Guid id)
        {
            UpdateScore(id, true);
        }

        public void AwayTeamScored(Guid id)
        {
            UpdateScore(id, false);
        }

        private void UpdateScore(Guid id, bool homeTeamScored)
        {
            var footballMatch = _storage.GetById(id);

            if (homeTeamScored)
            {
                footballMatch.HomeTeamScore++;
            }
            else
            {
                footballMatch.AwayTeamScore++;
            }
        }
    }
}
