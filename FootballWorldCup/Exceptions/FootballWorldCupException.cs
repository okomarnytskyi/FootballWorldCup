using System;

namespace FootballWorldCup.Implementation.Exceptions
{
    public class FootballWorldCupException : Exception
    {
        public FootballWorldCupException() : base() { }

        public FootballWorldCupException(string message) : base(message) { }

        public FootballWorldCupException(string message, Exception innerException) : base(message, innerException) { }
    }
}
