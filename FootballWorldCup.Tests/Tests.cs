using FootballWorldCup.Implementation.Exceptions;
using FootballWorldCup.Implementation.Managers;
using NUnit.Framework;
using System.Linq;

namespace FootballWorldCup.Tests
{
    public sealed class Tests
    {
        private IManager _manager;

        [SetUp]
        public void Setup()
        {
            _manager = new FootballGamesManager();
        }

        [Test]
        public void StartThreeGames_CheckIfMatchesCorrectlyOrdered()
        {
            var ukraineItalyId = _manager.StartGame(NationalTeams.Ukraine.ToString(), 
                                                    NationalTeams.Italy.ToString());

            var germanyArgentinaId = _manager.StartGame(NationalTeams.Germany.ToString(),
                                                        NationalTeams.Argentina.ToString());

            var spainFranceId = _manager.StartGame(NationalTeams.Spain.ToString(),
                                                   NationalTeams.France.ToString());

            _manager.HomeTeamScored(ukraineItalyId);    // 1-0

            _manager.HomeTeamScored(germanyArgentinaId);    // 1-0
            _manager.AwayTeamScored(germanyArgentinaId);    // 1-1

            _manager.HomeTeamScored(spainFranceId);     // 1-0
            _manager.HomeTeamScored(spainFranceId);     // 2-0
            _manager.AwayTeamScored(spainFranceId);     // 2-1    

            var scoreboard = _manager.GetScoreboard();
            var firstMatchOnTheScoreboard = scoreboard.FootballMatches.First();

            Assert.AreEqual(3, scoreboard.FootballMatches.Count());
            Assert.AreEqual(3, firstMatchOnTheScoreboard.HomeTeamScore + firstMatchOnTheScoreboard.AwayTeamScore);
            Assert.AreEqual(NationalTeams.Spain.ToString(), firstMatchOnTheScoreboard.HomeTeamName);
            Assert.AreEqual(NationalTeams.France.ToString(), firstMatchOnTheScoreboard.AwayTeamName);
            Assert.AreEqual(2, firstMatchOnTheScoreboard.HomeTeamScore);
            Assert.AreEqual(1, firstMatchOnTheScoreboard.AwayTeamScore);
        }

        [Test]
        public void FinishGame_CheckIfScoreboardIsEmpty_CheckIfThrowsExceptionWhenTryingToFinishFinishedGame()
        {
            var ukraineItalyId = _manager.StartGame(NationalTeams.Ukraine.ToString(),
                                                    NationalTeams.Italy.ToString());

            _manager.FinishGame(ukraineItalyId);
            var scoreboard = _manager.GetScoreboard();

            Assert.IsEmpty(scoreboard.FootballMatches);
            Assert.Throws<FootballWorldCupException>(() => _manager.FinishGame(ukraineItalyId));
        }

        [Test]
        public void StartGame_CheckIfThrowsExceptionWhenTryingToStartStartedGame()
        {
            _ = _manager.StartGame(NationalTeams.Ukraine.ToString(),
                                   NationalTeams.Italy.ToString());

            Assert.Throws<FootballWorldCupException>(() => _manager.StartGame(NationalTeams.Ukraine.ToString(),
                                                                              NationalTeams.Italy.ToString()));
        }
    }
}