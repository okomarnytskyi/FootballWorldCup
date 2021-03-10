using FootballWorldCup.Implementation;

namespace FootballWorldCupTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ukraine = "Ukraine";
            var italy = "Italy";
            var germany = "Germany";
            var spain = "Spain";
            var brazil = "Brazil";
            var argentina = "Argentina";
            var s = new FootballGamesManager();
            s.StartGame(ukraine, italy);
            s.StartGame(spain, germany);
            s.StartGame(brazil, argentina);
            var s12 = s.GetScoreboard();
            s.HomeTeamScored(ukraine, italy);
            var s3 = s.GetScoreboard();
        }
    }
}
