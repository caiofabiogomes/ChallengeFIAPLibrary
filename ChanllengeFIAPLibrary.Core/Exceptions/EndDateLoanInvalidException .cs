namespace ChallengeFIAPLibrary.Domain.Exceptions
{
    public class EndDateLoanInvalidException : Exception
    {
        public EndDateLoanInvalidException(string message) : base(message)
        {
        }
    }
}
